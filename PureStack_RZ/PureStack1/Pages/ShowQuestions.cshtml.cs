using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PureStack;
using PureStack.Classes;

namespace PureStack1.Pages
{
    public class ShowQuestionsModel : SharedModel
    {
        private List<Question> _questions;
        private List<Question> _pageQuestions;
        private int _page = 1;
        private bool _isLastPage = false;

        public List<Question> Questions { get => _pageQuestions; }
        public List<Question> AllQuestions { get => _questions; }
        public bool LastPage { get => _isLastPage; }
        public int PageNum { get => _page; }
        private const int QUESTION_PER_PAGE = 6;
        public void OnGet(string p)
        {
            _pageQuestions = new List<Question>();
            _page = 1;
            if (p != null) _page = int.Parse(p);
            _isLastPage = false;

            try
            {
                _questions = QuestionSQL.ShowAllQuestions();
            }
            catch (DALException e)
            {
                _questions = new List<Question>();
                Response.Redirect("Error");
                return;
            }
            
            int id = 0;
            int numPages = (int)Math.Ceiling(Convert.ToDecimal(_questions.Count) / QUESTION_PER_PAGE);
            if (numPages == 0)
            {
                Response.Redirect("Index");
                return;
            }
            if ((_page * QUESTION_PER_PAGE) - (QUESTION_PER_PAGE-1) > _questions.Count)
                Response.Redirect("ShowQuestions?p=" + numPages);
            
            for (id = (_page * 6) - (QUESTION_PER_PAGE-1); id <= _page * QUESTION_PER_PAGE; id++)// page 1 = id 1, page 2 = id 5..
            {
                if (id - 1 < _questions.Count)
                {
                    Question question = _questions[id - 1];
                    _pageQuestions.Add(question);
                }
            }
            if (numPages == _page)
                _isLastPage = true;

        }
    }
}
