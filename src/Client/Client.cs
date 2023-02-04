using Dioscuri.Core;
using Terminal.Gui;

namespace Dioscuri
{
    public class Client
    {
        private readonly IBrowserEngine _browserEngine;

        public Client(IBrowserEngine browserEngine)
        {
            _browserEngine = browserEngine;
        }

        public void StartClient()
        {
            Application.Init();
            Colors.Base.Normal = Application.Driver.MakeAttribute (Color.Green, Color.Black);

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

            var mainWindow = new Window()
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            top.Add(mainWindow);

            var browserFrame = new FrameView("")
            {
                X = 0,
                Y = 3,
                Width = Dim.Fill(),
                Height = Dim.Fill(),
                CanFocus = true,
            };

            mainWindow.Add(browserFrame);


            var browserTextArea = new TextView()
            {
                Width= Dim.Fill(),
                Height= Dim.Fill(),
                WordWrap = true,
                ReadOnly = true,
            };

            browserFrame.Add(browserTextArea);


            var urlBar = new FrameView("Browse")
            {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = 3,
                CanFocus = true,
            };

            mainWindow.Add (urlBar);

            var urlField = new TextField("gemini://gemini.circumlunar.space")
            {
                Width = Dim.Fill()  - 7,
                CanFocus = true
            };

            urlBar.Add (urlField);

            var urlButton = new Button("Go")
            {
                X = Pos.Right (urlField) + 1,
            };

            urlButton.Clicked += () =>
            {
                // Make request using input from urlField
                var pageContent = _browserEngine.DownloadContent(urlField.Text.ToString() ?? "");

                browserTextArea.Text = pageContent;
            };

            urlBar.Add(urlButton);


            var statusBar = new StatusBar(new StatusItem[]
            {
                new StatusItem(Key.F4, "~F4~ Quit", () => Application.RequestStop()),
            });

            top.Add(statusBar);

            Application.Run();
            Application.Shutdown();
        }
    }
}
