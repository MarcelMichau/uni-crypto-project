using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace CryptoSpade
{
    public partial class Form1 : Form
    {
        private byte[] _decryptedFile = new byte[1];
        private byte[] _encryptedFile = new byte[1];
        private byte[] _fileBytes = new byte[1];

        public Form1()
        {
            InitializeComponent();

            FilePathTextBox.AllowDrop = true;
            FileKeyBox.AllowDrop = true;
            FilePathTextBox.DragOver += FilePathTextBox_DragOver;
            FilePathTextBox.DragDrop += FilePathTextBox_DragDrop;
            FileKeyBox.DragOver += FileKeyBox_DragOver;
            FileKeyBox.DragDrop += FileKeyBox_DragDrop;
        }

        private void ClearAllFileButton_Click(object sender, EventArgs e)
        {
            FilePathTextBox.Clear();
            FileKeyBox.Clear();
        }

        private void ClearAllTextButton_Click(object sender, EventArgs e)
        {
            PlainTextBox.Clear();
            TextKeyBox.Clear();
            EncryptedTextBox.Clear();
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            if (TextRadioButton.Checked)
            {
                if ((EncryptionStrengthComboBox.SelectedIndex > -1) && (EncryptionAlgorithmComboBox.SelectedIndex > -1))
                {
                    if (EncryptionStrengthComboBox.SelectedIndex == 0)
                    {
                        var plaintext = string.Empty;
                        var encryptedstring = EncryptedTextBox.Text;

                        switch (EncryptionAlgorithmComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    try
                                    {
                                        var shiftvalue = Convert.ToInt32(TextKeyBox.Text);
                                        var caesar = new Caesar(shiftvalue);
                                        plaintext = caesar.Decrypt(encryptedstring);
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show(@"Key must be an integer value.", @"Key Format Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;

                            case 1:
                                {
                                    var key = TextKeyBox.Text;
                                    var vernam = new Vernam(key);
                                    plaintext = vernam.Decrypt(encryptedstring);
                                }
                                break;

                            case 2:
                                {
                                    var keystring = TextKeyBox.Text;
                                    var key = keystring.Split(',').Select(int.Parse).ToArray();
                                    var transposition = new Transposition(key);
                                    plaintext = transposition.Decrypt(encryptedstring);
                                }
                                break;

                            case 3:
                                {
                                    try
                                    {
                                        var key = TextKeyBox.Text;
                                        var vigenere = new Vigenere(key);
                                        plaintext = vigenere.Decrypt(encryptedstring);
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show(@"Key must be an string value.", @"Key Format Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                        }
                        PlainTextBox.Text = plaintext;
                    }
                    if (EncryptionStrengthComboBox.SelectedIndex == 1)
                    {
                        var plaintext = string.Empty;
                        var encryptedstring = EncryptedTextBox.Text;

                        switch (EncryptionAlgorithmComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    var key = TextKeyBox.Text;
                                    new StrongEncrypt(key);
                                    plaintext = StrongEncrypt.Decrypt<AesManaged>(encryptedstring);
                                }
                                break;

                            case 1:
                                {
                                    var key = TextKeyBox.Text;
                                    new StrongEncrypt(key);
                                    plaintext = StrongEncrypt.Decrypt<RijndaelManaged>(encryptedstring);
                                }
                                break;
                        }
                        PlainTextBox.Text = plaintext;
                    }
                }
                else
                {
                    MessageBox.Show(@"Please select an encryption strength and algorithm", @"Encryption Method Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (FileRadioButton.Checked)
            {
                if ((EncryptionStrengthComboBox.SelectedIndex > -1) && (EncryptionAlgorithmComboBox.SelectedIndex > -1))
                {
                    if (EncryptionStrengthComboBox.SelectedIndex == 0)
                    {
                        var filepath = FilePathTextBox.Text;

                        switch (EncryptionAlgorithmComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    try
                                    {
                                        var shiftvalue = Convert.ToInt32(FileKeyBox.Text);
                                        var caesar = new Caesar(shiftvalue);
                                        caesar.Decrypt(filepath);
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show(@"Key must be an integer value.", @"Key Format Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;

                            case 1:
                                {
                                    var keypath = FileKeyBox.Text;
                                    var vernam = new Vernam(keypath);

                                    var index = filepath.IndexOf(".", StringComparison.Ordinal);
                                    var ext = string.Empty;

                                    if (index > 0)
                                        ext = filepath.Substring(index);

                                    vernam.DecryptFile(filepath, filepath.Remove(filepath.IndexOf('_')) + "_decrypted" + ext);
                                }
                                break;

                            case 2:
                                {
                                    var keystring = FileKeyBox.Text;
                                    var index = filepath.IndexOf(".", StringComparison.Ordinal);
                                    _fileBytes = File.ReadAllBytes(filepath);
                                    new Transposition();
                                    var ext = string.Empty;

                                    if (index > 0)
                                        ext = filepath.Substring(index);

                                    var decryptedFile = Transposition.DecryptFile(_fileBytes, keystring);
                                    var newpath = filepath.Remove(filepath.IndexOf('_')) + "_decrypted" + ext;
                                    File.WriteAllBytes(newpath, decryptedFile);
                                }
                                break;

                            case 3:
                                {
                                    var key = FileKeyBox.Text;
                                    _fileBytes = File.ReadAllBytes(filepath);
                                    var vigenere = new Vigenere(key);
                                    _decryptedFile = vigenere.DecryptFile(_fileBytes);

                                    var index = filepath.IndexOf(".", StringComparison.Ordinal);
                                    var ext = string.Empty;

                                    if (index > 0)
                                        ext = filepath.Substring(index);

                                    File.WriteAllBytes(filepath.Remove(filepath.IndexOf('_')) + "_decrypted" + ext, _decryptedFile);
                                }
                                break;
                        }
                    }
                    if (EncryptionStrengthComboBox.SelectedIndex == 1)
                    {
                        var encryptedstring = FilePathTextBox.Text;

                        switch (EncryptionAlgorithmComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    var key = FileKeyBox.Text;
                                    new StrongEncrypt(key);
                                    StrongEncrypt.Decrypt<AesManaged>(encryptedstring);
                                }
                                break;

                            case 1:
                                {
                                    var key = FileKeyBox.Text;
                                    new StrongEncrypt(key);
                                    StrongEncrypt.Decrypt<RijndaelManaged>(encryptedstring);
                                }
                                break;
                        }
                    }
                    MessageBox.Show(@"Your file has been decrypted", @"Decryption Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(@"Please select an encryption strength and algorithm", @"Encryption Method Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            if (TextRadioButton.Checked)
            {
                if ((EncryptionStrengthComboBox.SelectedIndex > -1) && (EncryptionAlgorithmComboBox.SelectedIndex > -1))
                {
                    if (EncryptionStrengthComboBox.SelectedIndex == 0)
                    {
                        var plaintext = PlainTextBox.Text;
                        var encryptedstring = string.Empty;

                        switch (EncryptionAlgorithmComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    try
                                    {
                                        var shiftvalue = Convert.ToInt32(TextKeyBox.Text);
                                        var caesar = new Caesar(shiftvalue);
                                        plaintext = plaintext.Replace(" ", "");
                                        encryptedstring = caesar.Encrypt(plaintext);
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show(@"Key must be an integer value.", @"Key Format Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;

                            case 1:
                                {
                                    var key = TextKeyBox.Text;
                                    var vernam = new Vernam(key);
                                    encryptedstring = vernam.Encrypt(plaintext);
                                }
                                break;

                            case 2:
                                {
                                    try
                                    {
                                        var keystring = TextKeyBox.Text;
                                        var key = keystring.Split(',').Select(int.Parse).ToArray();
                                        var transposition = new Transposition(key);
                                        encryptedstring = transposition.Encrypt(plaintext);
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show(@"Key must be in the format: 1,2,3,4.", @"Key Format Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    catch (KeyNotFoundException)
                                    {
                                        MessageBox.Show(@"Key must be in the format: 1,2,3,4.", @"Key Format Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;

                            case 3:
                                {
                                    try
                                    {
                                        var key = TextKeyBox.Text;
                                        var vigenere = new Vigenere(key);
                                        plaintext = plaintext.Replace(" ", "");
                                        encryptedstring = vigenere.Encrypt(plaintext);
                                    }
                                    catch (FormatException)
                                    {
                                        MessageBox.Show(@"Key must be an string value.", @"Key Format Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                break;
                        }
                        EncryptedTextBox.Text = encryptedstring;
                    }
                    if (EncryptionStrengthComboBox.SelectedIndex == 1)
                    {
                        var plaintext = PlainTextBox.Text;
                        var encryptedstring = string.Empty;

                        switch (EncryptionAlgorithmComboBox.SelectedIndex)
                        {
                            case 0:
                                {
                                    var key = TextKeyBox.Text;
                                    new StrongEncrypt(key);
                                    encryptedstring = StrongEncrypt.Encrypt<AesManaged>(plaintext);
                                }
                                break;

                            case 1:
                                {
                                    var key = TextKeyBox.Text;
                                    new StrongEncrypt(key);
                                    encryptedstring = StrongEncrypt.Encrypt<RijndaelManaged>(plaintext);
                                }
                                break;
                        }
                        EncryptedTextBox.Text = encryptedstring;
                    }
                }
                else
                {
                    MessageBox.Show(@"Please select an encryption strength and algorithm", @"Encryption Method Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (FileRadioButton.Checked)
            {
                if ((EncryptionStrengthComboBox.SelectedIndex > -1) && (EncryptionAlgorithmComboBox.SelectedIndex > -1))
                {
                    var filepath = FilePathTextBox.Text;
                    if (EncryptionStrengthComboBox.SelectedIndex == 0)
                    {
                        if (File.Exists(filepath))
                        {
                            switch (EncryptionAlgorithmComboBox.SelectedIndex)
                            {
                                case 0:
                                    {
                                        try
                                        {
                                            var shiftvalue = Convert.ToInt32(FileKeyBox.Text);
                                            var caesar = new Caesar(shiftvalue);
                                            caesar.Encrypt(filepath);
                                        }
                                        catch (FormatException)
                                        {
                                            MessageBox.Show(@"Key must be an integer value.", @"Key Format Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    break;

                                case 1:
                                    {
                                        var vernam = new Vernam(FilePathTextBox.Text.Remove(FilePathTextBox.Text.IndexOf('.')) + "_encrypted_key.dat");
                                        var index = filepath.IndexOf(".", StringComparison.Ordinal);
                                        var ext = string.Empty;

                                        if (index > 0)
                                            ext = filepath.Substring(index);

                                        vernam.EncryptFile(filepath, filepath.Remove(filepath.IndexOf('.')) + "_encrypted" + ext);
                                    }
                                    break;

                                case 2:
                                    {
                                        var keystring = FileKeyBox.Text;
                                        var index = filepath.IndexOf(".", StringComparison.Ordinal);
                                        _fileBytes = File.ReadAllBytes(filepath);
                                        new Transposition();
                                        var ext = string.Empty;

                                        if (index > 0)
                                            ext = filepath.Substring(index);

                                        var encryptedFile = Transposition.EncryptFile(_fileBytes, keystring);
                                        var newpath = filepath.Remove(filepath.IndexOf('.')) + "_encrypted" + ext;
                                        File.WriteAllBytes(newpath, encryptedFile);
                                    }
                                    break;

                                case 3:
                                    {
                                        var key = FileKeyBox.Text;
                                        _fileBytes = File.ReadAllBytes(filepath);
                                        var vigenere = new Vigenere(key);
                                        _encryptedFile = vigenere.EncryptFile(_fileBytes);

                                        var index = filepath.IndexOf(".", StringComparison.Ordinal);
                                        var ext = string.Empty;

                                        if (index > 0)
                                            ext = filepath.Substring(index);

                                        File.WriteAllBytes(filepath.Remove(filepath.IndexOf('.')) + "_encrypted" + ext, _encryptedFile);
                                    }
                                    break;
                            }
                            MessageBox.Show(@"Your file has been encrypted", @"Encryption Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(@"File not found.", @"File Not Found Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (EncryptionStrengthComboBox.SelectedIndex == 1)
                    {
                        var plaintext = FilePathTextBox.Text;

                        if (File.Exists(filepath))
                        {
                            switch (EncryptionAlgorithmComboBox.SelectedIndex)
                            {
                                case 0:
                                    {
                                        var key = FileKeyBox.Text;
                                        new StrongEncrypt(key);
                                        StrongEncrypt.Encrypt<AesManaged>(plaintext);
                                    }
                                    break;

                                case 1:
                                    {
                                        var key = FileKeyBox.Text;
                                        new StrongEncrypt(key);
                                        StrongEncrypt.Encrypt<RijndaelManaged>(plaintext);
                                    }
                                    break;
                            }
                            MessageBox.Show(@"Your file has been encrypted", @"Encryption Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(@"File not found.", @"File Not Found Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Please select an encryption strength and algorithm", @"Encryption Method Not Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EncryptionAlgorithmComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TextRadioButton.Checked)
            {
                if (EncryptionStrengthComboBox.SelectedIndex == 0)
                {
                    if (EncryptionAlgorithmComboBox.SelectedIndex == 0)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.Caesar;
                    }

                    if (EncryptionAlgorithmComboBox.SelectedIndex == 1)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.Vernam;
                    }

                    if (EncryptionAlgorithmComboBox.SelectedIndex == 2)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.Transposition;
                    }

                    if (EncryptionAlgorithmComboBox.SelectedIndex == 3)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.Vigenere;
                    }
                }
                if (EncryptionStrengthComboBox.SelectedIndex == 1)
                {
                    if (EncryptionAlgorithmComboBox.SelectedIndex == 0)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.AES;
                    }

                    if (EncryptionAlgorithmComboBox.SelectedIndex == 1)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.Rijndael;
                    }
                }
            }
            if (FileRadioButton.Checked)
            {
                if (EncryptionStrengthComboBox.SelectedIndex == 0)
                {
                    if (EncryptionAlgorithmComboBox.SelectedIndex == 0)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.CaesarFile;
                    }

                    if (EncryptionAlgorithmComboBox.SelectedIndex == 1)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.VernamFile;
                    }

                    if (EncryptionAlgorithmComboBox.SelectedIndex == 2)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.TranspositionFile;
                    }

                    if (EncryptionAlgorithmComboBox.SelectedIndex == 3)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.VigenereFile;
                    }
                }
                if (EncryptionStrengthComboBox.SelectedIndex == 1)
                {
                    if (EncryptionAlgorithmComboBox.SelectedIndex == 0)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.AESFile;
                    }

                    if (EncryptionAlgorithmComboBox.SelectedIndex == 1)
                    {
                        AlgorithmInfoTextBox.Text = Properties.Resources.RijndaelFile;
                    }
                }
            }
        }

        private void EncryptionStrengthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var dataSource = new List<ComboBoxPopulate>();

            if (EncryptionStrengthComboBox.SelectedIndex == 0)
            {
                dataSource.Add(new ComboBoxPopulate { Name = "Caesar Cipher", Value = "Caesar" });
                dataSource.Add(new ComboBoxPopulate { Name = "Vernam Cipher", Value = "Vernam" });
                dataSource.Add(new ComboBoxPopulate { Name = "Transposition Cipher", Value = "Transposition" });
                dataSource.Add(new ComboBoxPopulate { Name = "Vigenere Tableau", Value = "Vigenere Tableau" });
            }
            else
            {
                dataSource.Add(new ComboBoxPopulate { Name = "AES Managed", Value = "AES" });
                dataSource.Add(new ComboBoxPopulate { Name = "Rijndael Managed", Value = "Rijndael" });
            }

            EncryptionAlgorithmComboBox.DataSource = dataSource;
            EncryptionAlgorithmComboBox.DisplayMember = "Name";
            EncryptionAlgorithmComboBox.ValueMember = "Value";
        }

        private void FileKeyBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (File.Exists(files[0]))
                FileKeyBox.Text = files[0];
        }

        private static void FileKeyBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void FilePathTextBox_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) return;
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (File.Exists(files[0]))
                FilePathTextBox.Text = files[0];
        }

        private static void FilePathTextBox_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        private void FileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            TextRadioButton.Select();
            EncryptionStrengthComboBox.SelectedIndex = 0;
        }

        private void TextRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = true;
            groupBox3.Enabled = false;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
                {
                    Filter = @"All files (*.*)|*.*",
                    InitialDirectory = @"C:\",
                    Title = @"Please select a file to encrypt."
                };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                FilePathTextBox.Text = dialog.FileName;
            }
        }

        private void PlainTextBox_TextChanged(object sender, EventArgs e)
        {
            TextLengthLabel.Text = "";
            if ((EncryptionAlgorithmComboBox.SelectedIndex != 1) && (EncryptionStrengthComboBox.SelectedIndex != 0)) return;
            TextLengthLabel.Text = @"Length: " + PlainTextBox.Text.Length;

            if (PlainTextBox.Text.Length == 0)
                TextLengthLabel.Text = "";
        }

        private void TextKeyBox_TextChanged(object sender, EventArgs e)
        {
            KeyLengthLabel.Text = "";
            if ((EncryptionAlgorithmComboBox.SelectedIndex != 1) && (EncryptionStrengthComboBox.SelectedIndex != 0)) return;
            KeyLengthLabel.Text = @"Length: " + TextKeyBox.Text.Length;

            if (TextKeyBox.Text.Length == 0)
                KeyLengthLabel.Text = "";
        }
    }

    public class ComboBoxPopulate
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}