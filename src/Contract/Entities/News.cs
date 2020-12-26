using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Contract
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Content { get; private set; }

        public string Summary { get; private set; }

        public string SummaryByWordRate { get; set; }
        private List<Sentence> Sentences { get; set; }
        private List<string> Subsets { get; set; }

        public News(string title, string content)
        {
            this.Title = title;
            Content = content;

        }
        public News(int id, string title, string content) : this(title: title, content: content)
        {
            Id = id;

        }
        public void ChangeTitle(string title)
        {
            Title = title;
        }
        public void ChangeContent(string content)
        {
            Content = content;
        }
        public void CreateSummary()
        {
            SetTitleOfNewsSubset();
            Summary = SetSummary();
            SetContentOfNewsSubset();
            SummaryByWordRate = SetSummary();
        }

        private string SetSummary()
        {
            var sentenceCount = 3;
            var firstThreeSentence = Sentences.OrderByDescending(i => i.Score).Take(sentenceCount).OrderBy(s => s.NumberOfLines).Select(s => s.Line);

            Sentences = new List<Sentence>();

            return String.Join('.', firstThreeSentence); ;

        }
        private void SetTitleOfNewsSubset()
        {

            Subsets = Title.Split(" ").ToList();
            SetSentences();
        }
        private void SetContentOfNewsSubset()
        {
            var highRepeatWordCountForSubset = 5;
            Subsets=  Content.Split(" ").ToList().GroupBy(w => w)
                .Select(w => new
                {
                    word = w.Key,
                    Count = w.Count()
                }
            ).OrderByDescending(w => w.Count).Select(w => w.word)
            .Take(highRepeatWordCountForSubset).ToList();

            SetSentences();
        }
        private void SetSentences()
        {
            Sentences = new List<Sentence>();
            var lineNumber = 1;
            foreach (var sentence in Content.Replace("\r", " ").Replace("\n", " ").Split(new[] { ". " }, StringSplitOptions.None))
            {
                Sentences.Add(new Sentence(sentence, lineNumber, Subsets));
                lineNumber++;
            }
        }

    }
}
