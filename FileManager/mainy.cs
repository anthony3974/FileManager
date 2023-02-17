using FileManager;
using FileManager.MediaManipulation;

class mainy
{
    public static void Main()
    {
        // ffscanner
        //FFScaner fFScaner = new FFScaner();
        string pFile = FFScaner.ScanFiles(".", ".py")[0];
        string[] pFiles = FFScaner.ScanFiles(".", ".py").ToArray();
        string[] mFiles = FFScaner.ScanFiles(".", ".mp4").ToArray();
        string[] MFiles = FFScaner.ScanFiles(".", ".mp3").ToArray();

        // file rename
        /*
        FileRename fr = new FileRename(pFile);

        fr.ReName("mp()");
        fr.ReName("mp(1)");
        fr.ReName("mp()");

        fr.RemoveSpecial();

        fr.RemoveSpaces(true);
        */
        // file renamer
        /*
        FileRenamer fR = new FileRenamer(pFiles);

        fR.RemoveSpecial();

        fR.RemoveSpaces(true);
        */
        /*
        MovieRenamer mr = new MovieRenamer(mFiles);

        mr.Fix();
        mr.Fix();
        */

        MusicRenamer Mr = new MusicRenamer(MFiles);

        Mr.Fix();

    }
}
