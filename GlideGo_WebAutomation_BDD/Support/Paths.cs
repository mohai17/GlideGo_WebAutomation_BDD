


using System.Xml.Linq;

namespace ProjectUtilityPaths
{
    public static class Paths
    {

        public static string DataXLSXPath(string XLName)
        {
            string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
            string localfilePath = Path.Combine(projectRoot, "Resources/TestData", $"{XLName}");

            return localfilePath;
        }


    }
}
