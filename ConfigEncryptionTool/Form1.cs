using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace ConfigEncryptionTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ApplyTheme("Light"); // Default theme
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Config files (*.config)|*.config";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtConfigFilePath.Text = openFileDialog.FileName;
                LoadConfigData(openFileDialog.FileName);
            }
        }

        private void LoadConfigData(string configFilePath)
        {
            lstConnectionStrings.Items.Clear();
            lstAppSettings.Items.Clear();
            txtValue.Clear();

            var map = new ExeConfigurationFileMap { ExeConfigFilename = configFilePath };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            // Load connection strings
            foreach (ConnectionStringSettings connectionString in config.ConnectionStrings.ConnectionStrings)
            {
                if (connectionString.Name != "LocalSqlServer")
                {
                    lstConnectionStrings.Items.Add(connectionString.Name);
                }
            }

            // Load app settings
            foreach (string key in config.AppSettings.Settings.AllKeys)
            {
                lstAppSettings.Items.Add(key);
            }
        }

        private void lstConnectionStrings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstConnectionStrings.SelectedItem != null)
            {
                // Clear selection in App Settings list box
                lstAppSettings.ClearSelected();

                string selectedConnectionString = lstConnectionStrings.SelectedItem.ToString();
                var map = new ExeConfigurationFileMap { ExeConfigFilename = txtConfigFilePath.Text };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                ConnectionStringsSection section = config.ConnectionStrings;

                if (section.ConnectionStrings[selectedConnectionString] != null)
                {
                    txtValue.Text = section.ConnectionStrings[selectedConnectionString].ConnectionString;
                }
            }
        }

        private void lstAppSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstAppSettings.SelectedItem != null)
            {
                // Clear selection in Connection Strings list box
                lstConnectionStrings.ClearSelected();

                string selectedAppSetting = lstAppSettings.SelectedItem.ToString();
                var map = new ExeConfigurationFileMap { ExeConfigFilename = txtConfigFilePath.Text };
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
                AppSettingsSection section = config.AppSettings;

                if (section.Settings[selectedAppSetting] != null)
                {
                    txtValue.Text = section.Settings[selectedAppSetting].Value;
                }
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            if (lstConnectionStrings.SelectedItem != null)
            {
                string selectedConnectionString = lstConnectionStrings.SelectedItem.ToString();
                EncryptConnectionString(selectedConnectionString);
                LoadConfigData(txtConfigFilePath.Text);
            }
            else if (lstAppSettings.SelectedItem != null)
            {
                string selectedAppSetting = lstAppSettings.SelectedItem.ToString();
                EncryptAppSetting(selectedAppSetting);
                LoadConfigData(txtConfigFilePath.Text);
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            if (lstConnectionStrings.SelectedItem != null)
            {
                string selectedConnectionString = lstConnectionStrings.SelectedItem.ToString();
                DecryptConnectionString(selectedConnectionString);
                LoadConfigData(txtConfigFilePath.Text);
            }
            else if (lstAppSettings.SelectedItem != null)
            {
                string selectedAppSetting = lstAppSettings.SelectedItem.ToString();
                DecryptAppSetting(selectedAppSetting);
                LoadConfigData(txtConfigFilePath.Text);
            }
        }

        private void EncryptConnectionString(string name)
        {
            var map = new ExeConfigurationFileMap { ExeConfigFilename = txtConfigFilePath.Text };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            if (config.ConnectionStrings.ConnectionStrings[name] != null)
            {
                string encrypted = Encrypt(config.ConnectionStrings.ConnectionStrings[name].ConnectionString);
                config.ConnectionStrings.ConnectionStrings[name].ConnectionString = encrypted;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private void DecryptConnectionString(string name)
        {
            var map = new ExeConfigurationFileMap { ExeConfigFilename = txtConfigFilePath.Text };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            if (config.ConnectionStrings.ConnectionStrings[name] != null)
            {
                string decrypted = Decrypt(config.ConnectionStrings.ConnectionStrings[name].ConnectionString);
                config.ConnectionStrings.ConnectionStrings[name].ConnectionString = decrypted;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private void EncryptAppSetting(string key)
        {
            var map = new ExeConfigurationFileMap { ExeConfigFilename = txtConfigFilePath.Text };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] != null)
            {
                string encrypted = Encrypt(config.AppSettings.Settings[key].Value);
                config.AppSettings.Settings[key].Value = encrypted;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private void DecryptAppSetting(string key)
        {
            var map = new ExeConfigurationFileMap { ExeConfigFilename = txtConfigFilePath.Text };
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

            if (config.AppSettings.Settings[key] != null)
            {
                string decrypted = Decrypt(config.AppSettings.Settings[key].Value);
                config.AppSettings.Settings[key].Value = decrypted;
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private string Encrypt(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                byte[] key = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["EncryptionKey"]);
                byte[] iv = new byte[encryptor.BlockSize / 8];
                var encryptorTransform = encryptor.CreateEncryptor(key, iv);
                byte[] encryptedBytes = encryptorTransform.TransformFinalBlock(clearBytes, 0, clearBytes.Length);
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        private string Decrypt(string encryptedText)
        {
            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
            using (Aes decryptor = Aes.Create())
            {
                byte[] key = Encoding.UTF8.GetBytes(ConfigurationManager.AppSettings["EncryptionKey"]);
                byte[] iv = new byte[decryptor.BlockSize / 8];
                var decryptorTransform = decryptor.CreateDecryptor(key, iv);
                byte[] clearBytes = decryptorTransform.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                return Encoding.Unicode.GetString(clearBytes);
            }
        }

        // Theme support
        private void ApplyTheme(string theme)
        {
            if (theme == "Dark")
            {
                this.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
                this.ForeColor = System.Drawing.Color.White;
                foreach (Control control in this.Controls)
                {
                    if (control is Button)
                    {
                        control.BackColor = System.Drawing.Color.FromArgb(28, 28, 28);
                        control.ForeColor = System.Drawing.Color.White;
                    }
                    else if (control is TextBox || control is ListBox)
                    {
                        control.BackColor = System.Drawing.Color.FromArgb(30, 30, 30);
                        control.ForeColor = System.Drawing.Color.White;
                    }
                }
            }
            else // Default to Light theme
            {
                this.BackColor = System.Drawing.Color.White;
                this.ForeColor = System.Drawing.Color.Black;
                foreach (Control control in this.Controls)
                {
                    if (control is Button)
                    {
                        control.BackColor = System.Drawing.Color.LightGray;
                        control.ForeColor = System.Drawing.Color.Black;
                    }
                    else if (control is TextBox || control is ListBox)
                    {
                        control.BackColor = System.Drawing.Color.White;
                        control.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
        }

        private void btnThemeToggle_Click(object sender, EventArgs e)
        {
            string currentTheme = this.BackColor == System.Drawing.Color.White ? "Dark" : "Light";
            ApplyTheme(currentTheme);
        }
    }
}