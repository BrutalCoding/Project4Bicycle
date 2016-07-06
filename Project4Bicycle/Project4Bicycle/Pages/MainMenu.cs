﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Project4Bicycle
{
    class MainMenu : TabbedPage
    {
        public MainMenu()
        {
            Title = "Main menu";
            
            StolenPerMonthPage SPMP;
            ContainerOverviewPage COP;
            PieChartPage PCP;
            GroupedChartPage GCP;
            ShareLocationPage SLP;
            MapPage MP;
            COP = new ContainerOverviewPage();
            COP.Title = "Top 5 amount of bicycle containers";

            GCP = new GroupedChartPage();
            GCP.Title = "Ratio amount bicycles stolen & containers";

            SPMP = new StolenPerMonthPage();
            SPMP.Title = "Stolen bicycles per month";
            
            PCP = new PieChartPage();
            PCP.Title = "Most stolen bicycles and colours";

            SLP = new ShareLocationPage();
            SLP.Title = "Location of my bike";

            MP = new MapPage();
            MP.Title = "Map";

            Children.Add(COP);
            Children.Add(SPMP);
            Children.Add(PCP);
            Children.Add(GCP);
            Children.Add(SLP);
            Children.Add(MP);
        }
    }
}
