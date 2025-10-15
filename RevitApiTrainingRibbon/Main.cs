using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace RevitApiTrainingRibbon
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            string tabName = "RevitApiTraining";
            application.CreateRibbonTab(tabName);
            string utilsFolderPath_1 = @"C:\Users\alex206\Desktop\RevitApiTrainingUIElem";
            string utilsFolderPath_2 = @"C:\Users\alex206\Desktop\RevitApiTrainingUIWall";

            var panel = application.CreateRibbonPanel(tabName, "Стены");

            var button_1 = new PushButtonData("Информация об элементах", "Информация об элементах",
                Path.Combine(utilsFolderPath_1, "RevitApiTrainingUI.dll"),
                "RevitApiTrainingUI.Main");

            var button_2 = new PushButtonData("Смена типа стены", "Смена типа стены",
                Path.Combine(utilsFolderPath_2, "RevitApiTrainingUI.dll"),
                "RevitApiTrainingUI.Main");

            Uri uriImage = new Uri(@"C:\Users\alex206\Desktop\Курсы\ИТМО. Автоматизация информационного поделирования\Модуль 5\RevitApiTrainingRibbon\RevitApiTrainingRibbon\Images\RevitAPITrainingUI_32.png", UriKind.Absolute);
            BitmapImage largeImage = new BitmapImage(uriImage);
            button_2.LargeImage = largeImage;

            panel.AddItem(button_1);
            panel.AddItem(button_2);

            return Result.Succeeded;
        }
    }
}
