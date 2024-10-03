# Llama 3.1 Small Language Model (SLM) in ASP.NET MVC

This project demonstrates the integration of a **Small Language Model (SLM)**, specifically the **Llama 3.1** model by Meta, into an ASP.NET MVC application using the **Ollama** framework and **Microsoft Semantic Kernel** for AI-powered question answering.

Users can input a question into a web form and receive a concise, AI-generated response on the same page.

## Features

- **ASP.NET MVC Interface**: Allows users to interact with the Phi-3 model by entering questions and receiving responses.
- **Small Language Model**: The Llama 3.1 SLM provides local, lightweight, and fast AI responses.
- **Semantic Kernel**: Uses the Semantic Kernel to interact with and manage AI model queries.
- **Support for Multiple Models**: The application is configured to use the Llama 3.1 model but can be modified to use other models, such as Phi-3.

## Requirements

- .NET 7.0 or higher
- Ollama (to serve the Llama 3.1 or Phi-3 models locally)
- Semantic Kernel package for .NET

## Installation

### Step 1: Install Ollama

1. **Download Ollama**  
   Download Ollama from the official website: [Ollama Download](https://www.ollama.com/download)

2. **Install Ollama**  
   Follow the installation instructions specific to your operating system.

3. **Verify Ollama Installation**  
   After installation, run the following command in your terminal to check if it's installed properly:

   ```bash
   ollama
   ```

### Step 2: Pull the Model

1. For Llama 3.1 model:

   ```bash
   ollama pull llama3.1:latest
   ```

2. To pull the Phi-3 model:

   ```bash
   ollama pull phi3:latest
   ```

### Step 3: Set Up ASP.NET MVC Project

1. **Clone this repository**:

   ```bash
   git clone https://github.com/EbodShojaei/CS_MVC_AI.git
   ```

2. **Install .NET Core SDK**  
   Download and install the .NET SDK from [here](https://dotnet.microsoft.com/en-us/download/dotnet).

3. **Navigate to the project directory**:

   ```bash
   cd slmvc
   ```

4. **Restore the dependencies**:

   ```bash
   dotnet restore
   ```

5. **Run the project**:

   ```bash
   dotnet run
   ```

   The project should now be accessible locally in your browser.

### Step 4: Run the Ollama Server

To interact with the AI model, you need to run the Ollama server locally:

1. **Serve Phi-3**:

   ```bash
   ollama serve phi3:latest
   ```

2. **Serve Llama 3.1** (Optional):

   ```bash
   ollama serve llama3.1:latest
   ```

The Ollama server will now be running on `http://localhost:11434`.

### Step 5: Access the Application

Open your browser and navigate to:

```text
http://localhost:5272
```

This will bring up the ASP.NET MVC interface where you can ask questions and get responses from the AI model.

## Switching Between Models

By default, the application uses the **Llama 3.1** model. If you want to switch to the **Phi-3** model, follow these steps:

1. Open the `HomeController.cs` file.
2. Locate the `modelId: "llama3.1"` line in the constructor.
3. Replace `"llama3.1"` with `"phi3"`.

After making the change, restart both the Ollama server and the ASP.NET MVC application.

## Usage

1. Enter a question in the text input box on the web page.
2. Click the "Ask" button.
3. The AI response will be displayed below the input box in real time.

## Credits

Credits to Medhat Elmasry for another Master Class on the **Phi-3 Small Language Model (SLM)** integration with **Ollama** and **Microsoft Semantic Kernel** in a C# console application. The full tutorial can be found [here](https://blog.medhat.ca/2024/09/phi-3-small-language-model-slm-in-c.html).

## License

This project is open source and available under the MIT License. Feel free to fork and modify the project as per your requirements.
