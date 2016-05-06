using System;
using System.Collections.Generic;
using System.Text;

namespace DevNETCoder.Static
{
    public class SForm
    {
        private static Main _MainForm;
        private static Login _LoginForm;
        private static Index _Index;
        private static CreateList _CreateList;
        private static CreateAll _CreateAllQuery;
        private static ProgressBar _ProgressBar;
        private static ProgressBarC _ProgressBarC;
        private static CreateAllClass _CreateAllClass;

        public static Main MainForm
        {
            get
            {
                if (_MainForm == null)
                {
                    _MainForm = new Main();
                }
                return _MainForm;
            }
            set
            {
                _MainForm = value;
            }
        }
        public static Login LoginForm
        {
            get
            {
                if (_LoginForm == null)
                {
                    _LoginForm = new Login();
                }
                return _LoginForm;
            }
            set
            {
                _LoginForm = value;
            }
        }
        public static Index IndexForm
        {
            get
            {
                if (_Index == null)
                {
                    _Index = new Index();
                }
                return _Index;
            }
            set
            {
                _Index = value;
            }
        }
        public static CreateList CreateListForm
        {
            get
            {
                _CreateList = new CreateList();
                return _CreateList;
            }
            set
            {
                _CreateList = value;
            }
        }
        public static CreateAll CreateAllQueryForm
        {
            get
            {
                _CreateAllQuery = new CreateAll();
                return _CreateAllQuery;
            }
            set
            {
                _CreateAllQuery = value;
            }
        }
        public static ProgressBar ProgressBarForm
        {
            get
            {
                _ProgressBar = new ProgressBar();
                return _ProgressBar;
            }
            set
            {
                _ProgressBar = value;
            }
        }
        public static ProgressBarC ProgressBarCForm
        {
            get
            {
                _ProgressBarC = new ProgressBarC();
                return _ProgressBarC;
            }
            set
            {
                _ProgressBarC = value;
            }
        }
        public static CreateAllClass CreateAllClassForm
        {
            get
            {
                _CreateAllClass = new CreateAllClass();
                return _CreateAllClass;
            }
            set
            {
                _CreateAllClass = value;
            }
        }
        
    }
}
