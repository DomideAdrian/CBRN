using CBRN_Project.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBRN_Project.Data_Access
{
    public class IconRepository
    {
        #region Fields

        readonly List<Icon> icons;
        public static int   LastId { get; set; } = 1;

        #endregion

        #region Constructor

        public IconRepository()
        {
            icons = new List<Icon>();
        }

        #endregion

        #region Public Interface

        public event EventHandler<IconAddedEventArgs> IconAdded;

        public void AddIcon(Icon icon)
        {
            if (icon == null)
                throw new ArgumentNullException("icon");

            if(!icons.Contains(icon))
            {
                icons.Add(icon);
                LastId++;
                this.IconAdded?.Invoke(this, new IconAddedEventArgs(icon));
            }
        }

        public bool ContainsIcon(Icon icon)
        {
            if (icon == null)
                throw new ArgumentNullException("icon");

            return icons.Contains(icon);
        }

        public List<Icon> GetIcons()
        {
            return new List<Icon>(icons);
        }
        #endregion
        
    }
}
