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
            _folder = folder;

            Folder = folder;
        }

        public void Update()
        {
            SubItems.Clear();
            Text = _folder.FolderName;
            var nfoExists = _folder.NFOExists(_baseFolder);
            SubItems.Add(nfoExists.ToString());
            if (nfoExists)
                BackColor = MyColor.ToColor(Folder.Color);
        }
    }
}
