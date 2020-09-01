using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EventReactApp.Models;
using EventReactApp.Model;
using System.Diagnostics.Eventing.Reader;

namespace EventReactApp.Controllers
{
    public class HomeController : Controller
    {
        private IList<CommentModel> _comments;
        private IList<Events> _events;
        private IList<EventViewModel> _viewModels;
        private readonly EventAppContext dbContext;
        public HomeController(EventAppContext db)
        {
            dbContext = db;
            _viewModels = new List<EventViewModel>();
            _events = new List<Events>
            {
                new Events
                {
                    EventId = 1,
                    EventName = "Event1",
                    EventKeyword = "keyword",
                    EventSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new Events
                {
                    EventId = 2,
                    EventName = "Event2",
                    EventKeyword = "Keyword",
                    EventSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new Events
                {
                    EventId = 3,
                    EventName = "Event3",
                    EventKeyword = "Keyword",
                    EventSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new Events
                {
                    EventId = 4,
                    EventName = "Event4",
                    EventKeyword = "Keyword",
                    EventSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new Events
                {
                    EventId = 5,
                    EventName = "Event5",
                    EventKeyword = "Keyword",
                    EventSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                },
                new Events
                {
                    EventId = 6,
                    EventName = "Event6",
                    EventKeyword = "Keyword",
                    EventSummary = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
                }
            };

        }


        [Route("comments/new")]
        [HttpPost]
        public ActionResult AddComment(CommentModel comment)
        {
            // Create a fake ID for this comment
            comment.Id = _comments.Count + 1;
            _comments.Add(comment);
            return Content("Success :)");
        }

        public ActionResult Index()
        {
            return View(_viewModels);
        }

        [Route("eventsListings")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult EventsListings()
        {
            _events = dbContext.Events.ToList();
            foreach (Events ev in _events)
            {
                EventViewModel viewModel = new EventViewModel();
                viewModel.Id = ev.EventId;
                viewModel.Name = ev.EventName;
                //viewModel.Text = ev.EventKeyword + "\n" + ev.EventSummary + "\n\n";
                viewModel.KeywordForSearching = ev.EventKeyword;
                viewModel.Summary = ev.EventSummary;
                _viewModels.Add(viewModel);
            }
            return Json(_viewModels);
        }

        [Route("comments")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_comments);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
