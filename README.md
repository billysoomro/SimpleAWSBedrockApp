# SimpleAWSBedrockApp

This is a .NET 8 MVC application that interacts with the **AWS Bedrock** managed service to:
- Generate text
- Summarize text
- Generate images using various foundation models.

## Prerequisites

Before you begin, ensure you have the following installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [AWS CLI](https://aws.amazon.com/cli/)
- AWS credentials configured on your machine (using `aws configure`)

## Installation

1. **Clone the repository:**

    ```bash
    git clone https://github.com/billysoomro/SimpleImageDetector.git
    cd SimpleImageDetector
    ```

2. **Restore dependencies and build the project:**

    ```bash
    dotnet restore
    dotnet build
    ```

3. **Run the application:**

    ```bash
    dotnet run
    ```

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
