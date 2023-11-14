﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RehabilityApplication.CoreLib
{
    public partial class ucBackstageMenu : DevExpress.XtraEditors.XtraUserControl
    {
        ucNotifyMessages ucNotifyMessages = new ucNotifyMessages();
        public ucBackstageMenu()
        {
            InitializeComponent();

            tabNotifiesPanel.Controls.Add(ucNotifyMessages);
            CoreGlobalCommandManager.CommandInitialized += (s, e) =>
            {
                if(e.Command is EnumLanguageType.Russian || e.Command is EnumLanguageType.English)
                {
                    Relanguage();
                }
            };

        }

        private void Relanguage()
        {
            tabHelp.SetResourceString();
            btnExitApplication.SetResourceString();
            tabSettings.SetResourceString();
            tabNotifies.SetResourceString();
        }

    }
}


