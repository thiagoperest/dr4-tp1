using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Exercicio_11.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty] public string FirstName { get; set; } = string.Empty;

        [BindProperty] public string LastName { get; set; } = string.Empty;

        public bool IsProcessed { get; set; } = false;
        public string Step1Result { get; set; } = string.Empty;
        public string Step2Result { get; set; } = string.Empty;
        public string Step3Result { get; set; } = string.Empty;
        public string FinalResult { get; set; } = string.Empty;

        public void OnGet()
        {
            IsProcessed = false;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                Func<string, string, string> processString = ConcatenateNames;

                processString += ConvertToUpper;
                processString += RemoveSpaces;

                Step1Result = ConcatenateNames(FirstName, LastName);
                Step2Result = ConvertToUpper(FirstName, LastName);
                Step3Result = RemoveSpaces(FirstName, LastName);

                FinalResult = processString(FirstName, LastName);

                IsProcessed = true;
            }

            return Page();
        }

        private string ConcatenateNames(string firstName, string lastName)
        {
            return $"{firstName} {lastName}";
        }

        private string ConvertToUpper(string firstName, string lastName)
        {
            return $"{firstName} {lastName}".ToUpper();
        }

        private string RemoveSpaces(string firstName, string lastName)
        {
            return $"{firstName}{lastName}";
        }
    }
}