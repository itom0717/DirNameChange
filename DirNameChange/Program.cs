using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace DirNameChange
{
    class Program
    {
        static void Main( string[] args )
        {

            const string TgtDir  = @"G:\GamesSetup\PC18_退避\";

            string[] dirs = System.IO.Directory.GetDirectories( TgtDir );

            foreach ( var dir in dirs )
            {
                var dirPath = Common.File.GetDirectoryName(Common.File.DeleteDirectorySeparator(dir));
                var dirName = Common.File.GetFileName(Common.File.DeleteDirectorySeparator(dir));


                var r = new Regex( @"^(\[\d+\])\s*(\[.+\])\s*(.+)$", RegexOptions.IgnoreCase );
                var mc = r.Matches(dirName);
                if ( mc.Count >= 1 )
                {
                    var newDirName = $"{mc[0].Groups[2].Value} {mc[0].Groups[1].Value} {mc[0].Groups[3].Value}";
                    var newDirPath = Common.File.CombinePath(dirPath,newDirName);


                    //Console.WriteLine( newDirPath );



                    System.IO.Directory.Move( dir, newDirPath );



                }

            }




        }
    }
}
