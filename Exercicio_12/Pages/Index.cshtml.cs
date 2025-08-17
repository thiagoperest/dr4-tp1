using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Exercicio_12.Models;

namespace Exercicio_12.Pages
{
    public class IndexModel : PageModel
    {
        private static readonly List<Event> _events = new List<Event>();
        
        private static Action<Event> _onEventCreated = LogEventCreation;
        
        [BindProperty]
        public string EventTitle { get; set; } = string.Empty;
        
        [BindProperty]
        public DateTime EventDate { get; set; } = DateTime.Now;
        
        [BindProperty]
        public string EventLocation { get; set; } = string.Empty;
        
        public bool IsEventCreated { get; set; } = false;
        public Event CreatedEvent { get; set; } = new Event();
        public List<Event> EventsList { get; set; } = new List<Event>();

        public void OnGet()
        {
            IsEventCreated = false;
            EventsList = new List<Event>(_events);
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var newEvent = new Event
                {
                    Titulo = EventTitle,
                    Data = EventDate,
                    Local = EventLocation
                };
                
                _events.Add(newEvent);
                
                _onEventCreated?.Invoke(newEvent);
                
                CreatedEvent = newEvent;
                IsEventCreated = true;
                EventsList = new List<Event>(_events);
                
                EventTitle = string.Empty;
                EventDate = DateTime.Now;
                EventLocation = string.Empty;
            }
            
            return Page();
        }
        
        private static void LogEventCreation(Event eventObj)
        {
            Console.WriteLine($"Novo evento criado:");
            Console.WriteLine($"Título: {eventObj.Titulo}");
            Console.WriteLine($"Data: {eventObj.Data:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"Local: {eventObj.Local}");
            Console.WriteLine($"Timestamp: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
        }
    }
}