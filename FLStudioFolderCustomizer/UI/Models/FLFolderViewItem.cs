using FLStudioFolderCustomizer.Core.Models.Colors;
using FLStudioFolderCustomizer.Models;
using System.Windows.Forms;

namespace FLStudioFolderCustomizer.UI.Models
{
    public class FLFolderViewItem : ListViewItem
    {
        private readonly string _baseFolder;
        private FLFolder _folder;

        public FLFolder Folder
        {
            get
            {
                return _folder;
            }
            set
            {
                _folder = value;
                Update();
            }
        }

        public FLFolderViewItem(string baseFolder, FLFolder folder)
        {
            _baseFolder = baseFolder;
            Folder = folder;
        }

        public void Update()
        {
            SubItems.Clear();
            Text = _folder.FolderName;
            var nfoFileExists = _folder.NFOFileExists(_baseFolder);
            SubItems.Add(nfoFileExists.ToString());
            var nameIsCompliant = !Folder.FolderName.Contains(".");
            SubItems.Add(nameIsCompliant.ToString());

            if (nfoFileExists && nameIsCompliant)
                ForeColor = MyColor.ToColor(Folder.Color);
            else
                ForeColor = Config.FLBackColor;
        }
    }
}
