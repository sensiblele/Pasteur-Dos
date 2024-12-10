
# PeteteDoS 🚀💥

PeteteDoS is a **Layer 7 DoS (Denial of Service) attack** script written in C# that sends massive **POST** requests to a specified target URL with customizable settings. It is primarily designed for educational purposes to help understand and test the resilience of web servers to high traffic volumes (USE ONLY WITH PERMISSION).

## 📌 Description

**PeteteDoS** allows you to send a high volume of **POST** requests to a target URL with configurable parameters such as:

- **Number of threads** to perform requests in parallel 💻
- **Delay between requests** to control the rate of requests ⏳
- **Payload size** sent with each request 🔒

This tool can be used to simulate a **DoS attack** or stress test an application by overwhelming the server with traffic. It helps in understanding how servers react to traffic surges, though it should only be used on servers you have explicit permission to test.

> ⚠️ **Warning**: This tool should only be used on systems you have explicit permission to test. Unauthorized use may be illegal.

---

## 🛠️ Features

- **Complete customization**: Choose the target URL, the number of threads, the delay between each request, and the payload size.
- **POST requests with random payloads**: Each request contains a random payload encoded in base64, simulating real-world POST requests.
- **Real-time status tracking**: Monitor the success or failure of each request with color-coded output for better visibility.

---

## 🎯 How to Use

### 1. Clone the repository:

```bash
git clone https://github.com/hjcs-dev/PETETE-DoS.git
cd PETETE-DoS
```

### 2. Compile and run the code:
- Use your IDE to build the project, or use the `dotnet` command line tool:

```bash
dotnet build
dotnet run
```

### 3. Enter the requested information:

When running the script, you will be prompted to enter the following:

- **Target URL** (e.g., http://example.com)
- **Number of threads** (e.g., 10, for parallel requests)
- **Delay between requests** (in milliseconds)
- **Payload size** (in bytes)

Once entered, the script will begin sending POST requests according to the provided settings.

---

## 💡 Example

```bash
Enter the target URL: http://example.com
Enter the number of threads: 10
Enter the delay between requests (in milliseconds): 500
Enter the payload size (in bytes): 1024
```

After you enter the required information, the script will begin sending POST requests to the specified URL.

---

## 🔧 Notes

- The **payload** sent with each request is generated randomly to simulate dynamic data in the POST requests.
- You can adjust the **workload** by modifying the parameters to see how the server responds to different levels of traffic.

---

## 🧑‍💻 Requirements

- .NET Core 3.1 or later
- A terminal or IDE to build and run the project

---

## ⚠️ Disclaimer

This code is intended for educational purposes only. It should only be used on servers or systems you have explicit permission to test. Unauthorized use may be considered illegal and unethical.

---

## 📚 License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more information.

---

## 👨‍💻 Contribution

Feel free to contribute to the project by opening issues or submitting pull requests.

---

### 😎 Thank you for using **PeteteDoS**! 🚀

![PeteteDoS Demo](video.mp4)
