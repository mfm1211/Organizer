using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace OrganizerWPF
{
    public enum Skin { Light, Dark }
    public class ThemeResourceDictionary : ResourceDictionary
    {
        private Uri _lightTheme;
        private Uri _darkTheme;

        public Uri LightTheme
        {
            get { return _lightTheme; }
            set
            {
                _lightTheme = value;
                UpdateSource();
            }
        }
        public Uri DarkTheme
        {
            get { return _darkTheme; }
            set
            {
                _darkTheme = value;
                UpdateSource();
            }
        }

        private void UpdateSource()
        {
            var val = App.Skin == Skin.Light ? LightTheme : DarkTheme;
            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}