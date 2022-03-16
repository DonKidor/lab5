using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;
using System.Reactive;
using System.Text.RegularExpressions;
using System.IO;

namespace lab5.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string _mainText;
        public string MainText
        {
            get => _mainText;
            set
            {
                this.RaiseAndSetIfChanged(ref _mainText, value);
            }
        }
        string _regex;
        public string RegexPattern
        {
            get => _regex;
            set
            {
                this.RaiseAndSetIfChanged(ref _regex, value);
            }
        }

        string _answer;
        public string AnswerText
        {
            get => _answer;
            set => this.RaiseAndSetIfChanged(ref _answer, value);
        }

        public MainWindowViewModel() {
            this.WhenAnyValue(x => x.MainText, x => x.RegexPattern).Subscribe(text => RegexCalculate(MainText));
            
        }


        void RegexCalculate(string text)
        {
            if (RegexPattern == null || text==null) return;
            Regex rgx = new Regex(RegexPattern);
            var matches = rgx.Matches(text);
            AnswerText = "";
            foreach(Match match in matches)
            {
                AnswerText += $"{match.Value}\n";
            }
        }

        public void SaveFile(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Write(AnswerText);
            }
        }

        public void LoadFile(string path)
        {
            if(File.Exists(path))
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    string res = "";
                    string str;
                    while((str=sr.ReadLine())!=null)
                    {
                        res += str+'\n';
                    }
                    MainText = res;
                }
            }
        }
    }
}
