# 🚀 HackerNewsBestStoriesApi - Fast .NET 8 REST API

A high-performance ASP.NET Core Web API to fetch and return the **top "best stories"** from the Hacker News API.  
Optimized for **speed, scalability, and efficiency** with caching and asynchronous requests.

---

## 📌 Features
✅ **Retrieves top N "best stories" from Hacker News**  
✅ **Sorted by score (descending order)**  
✅ **Uses `HttpClientFactory` for efficient API calls**  
✅ **Caching with `MemoryCache` to reduce API load**  
✅ **Handles large traffic without overloading Hacker News API**

---

## 🛠 How to Run

### **1️⃣ Prerequisites**
Ensure you have **.NET 8 SDK** installed.  
Check your .NET version:
```sh
dotnet --version
```

### **2️⃣ Clone the Repository**
```sh
git clone https://github.com/adkruk/HackerNewsBestStoriesApi.git
cd HackerNewsAPI
```

### **3️⃣ Install Dependencies**
```sh
dotnet restore
```

### **4️⃣ Run the API**
```sh
dotnet run
```
Your API is now live at:  
🔗 `http://localhost:5000/best-stories/10` (Fetch **top 10** best stories)

### **5️⃣ Test API Using cURL**
```sh
curl http://localhost:5000/best-stories/5
```
Or open in a browser:  
👉 `http://localhost:5000/best-stories/5`

---

## 📡 API Endpoints
### **1️⃣ Get Top "Best Stories"**
```http
GET /best-stories/{count}
```
🔹 **Example:** `GET /best-stories/5`  
🔹 **Response Format:**
```json
[
  {
    "title": "A uBlock Origin update was rejected from the Chrome Web Store",
    "uri": "https://github.com/uBlockOrigin/uBlock-issues/issues/745",
    "postedBy": "ismaildonmez",
    "time": "2019-10-12T13:43:01+00:00",
    "score": 1716,
    "commentCount": 572
  }
]
```

---

## 🚀 Possible Enhancements & Improvements

🔹 **Redis Caching**  
Replace `MemoryCache` with **Redis** for better scalability in distributed environments.  
👉 `dotnet add package StackExchange.Redis`

🔹 **Rate Limiting**  
Implement `AspNetCoreRateLimit` to prevent abuse.  
👉 `dotnet add package AspNetCoreRateLimit`

🔹 **Pagination & Filtering**  
Allow pagination with parameters like:
```http
GET /best-stories?count=10&page=2
```

🔹 **Docker & Kubernetes Deployment**  
Run with Docker:
```sh
docker build -t hackernewsapi .
docker run -p 5000:5000 hackernewsapi
```

🔹 **Unit Tests**  
Add `xUnit` tests for API responses.  
👉 `dotnet add package xunit`

🔹 **CI/CD Pipeline**  
Automate testing & deployment with **GitHub Actions** or **Azure DevOps**.

---

## 🛠 Technologies Used
✅ **.NET 8**  
✅ **ASP.NET Core Minimal API**  
✅ **HttpClientFactory**  
✅ **MemoryCache**  
✅ **LINQ & Asynchronous Tasks**

---

## 📌 License
MIT License. Feel free to use and modify.

---

## 🎯 Summary
🔹 **High-performance API to fetch top "best stories" from Hacker News**.  
🔹 **Optimized with caching & async requests**.  
🔹 **Prevents API overload & ensures scalability**.

Would you like **Docker deployment instructions** or **unit testing details**? 🚀🔥

