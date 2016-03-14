using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Controls;

namespace WorksheetPrototype
{
    public static class ColumnThemeManager
    {
        private static XmlSerializer serializer = new XmlSerializer(typeof(List<ColumnInfo>));
        public static string GetDirectory()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return Path.GetDirectoryName(assembly.Location) + @"\ColumnTheme\";
        }

        public static IEnumerable<string> GetThemes()
        {
            string dir = GetDirectory();
            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            var directory = new DirectoryInfo(dir);
            foreach (var file in directory.GetFiles())
            {
                yield return file.Name;
            }
        }

        public static void Save(string themeName, DataGrid grid)
        {
            string dir = GetDirectory();
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var columnInfos = (from column in grid.Columns
                               select new ColumnInfo(column.Width.DisplayValue, column.DisplayIndex, column.Visibility)).ToList();

            using (FileStream fs = File.Create(dir + themeName))
            {
                serializer.Serialize(fs, columnInfos);
            }
        }

        public static void ApplyTheme(string themeName, DataGrid grid)
        {
            string dir = GetDirectory();
            using (FileStream fs = File.OpenRead(dir + themeName))
            {
                List<ColumnInfo> columnInfos = serializer.Deserialize(fs) as List<ColumnInfo>;
                for (int i = 0; i < columnInfos.Count; i++)
                {
                    grid.Columns[i].Width = columnInfos[i].Width;
                    grid.Columns[i].DisplayIndex = columnInfos[i].DisplayIndex;
                    grid.Columns[i].Visibility = columnInfos[i].Visibility;
                }
            }
        }

    }
}
