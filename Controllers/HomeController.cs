using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Text;

namespace SlmMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly Kernel _kernel;
        private readonly IChatCompletionService _chatService;

        public HomeController()
        {
            // Initialize the Semantic Kernel
            var builder = Kernel.CreateBuilder();
            builder.Services.AddOpenAIChatCompletion(
                modelId: "llama3.1",
                apiKey: null,
                endpoint: new Uri("http://localhost:11434")
            );
            _kernel = builder.Build();
            _chatService = _kernel.GetRequiredService<IChatCompletionService>();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AskQuestion(string userQuestion)
        {
            if (string.IsNullOrWhiteSpace(userQuestion))
            {
                ModelState.AddModelError(string.Empty, "Please enter a valid question.");
                return View("Index");
            }

            // Initialize chat history with the assistant prompt
            ChatHistory chat = new(@"
                You are an AI assistant that helps people find information.
                The response must be brief and should not exceed one paragraph.
                If you do not know the answer, simply say 'I do not know the answer'."
            );
            chat.AddUserMessage(userQuestion);

            StringBuilder responseBuilder = new();
            await foreach (var message in _chatService.GetStreamingChatMessageContentsAsync(chat, kernel: _kernel))
            {
                responseBuilder.Append(message.Content);
            }

            chat.AddAssistantMessage(responseBuilder.ToString());

            ViewBag.Answer = responseBuilder.ToString();
            return View("Index");
        }
    }
}
