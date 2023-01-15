using Terminal.Gui;

namespace Dioscuri
{
    public class Client
    {
        public void StartClient ()
        {
            Application.Init ();

            var top = Application.Top;

            var menuBar = new MenuBar(new MenuBarItem[] 
            {
                new MenuBarItem ("_File", new MenuItem [] 
                {
                    new MenuItem ("_Quit", "", () => 
                    {
                        Application.RequestStop ();
                    })
                }),

                new MenuBarItem("_Help", new MenuItem[]
                {
                    new MenuItem("_About", string.Empty, () =>
                    {
                        MessageBox.Query("Dioscuri 0.1.0", "\nDioscuri is a lightweight, cross-platform CLI\n Geminispace browser written in C#.\n\nDeveloped by Mark-James McDougall\nand licensed under the GPL v3.\n ", "Close");
                    }),
                })
            });

            top.Add (menuBar);

            // Create the playback controls frame.
            var urlBar = new FrameView ("Browse")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill (),
                Height = 3,
                CanFocus = true,
            };

            top.Add (urlBar);

            var urlField = new TextField("gemini://")
            {
                Width = Dim.Fill()
            };

            urlBar.Add (urlField);


            var browserWindow = new Window ("")
            {
                X = 0,
                Y = 4,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(browserWindow);

            var statusBar = new StatusBar(new StatusItem[]
            {
                new StatusItem(Key.F4, "~F4~ Quit", () => Application.RequestStop()),
            });

            top.Add (statusBar);

            Application.Run ();
            Application.Shutdown ();
        }
    }
}
