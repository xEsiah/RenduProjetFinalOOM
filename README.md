# RenduProjetFinalOOM

🎓 _Final project to validate the Object-Oriented Modeling (OOM) module._

---

## 🧩 UML Overview

### 📺 Series-related UML

- We assume a Protagonist appears in only one series, which may not always be true (e.g., Naruto appears in Naruto, Naruto Shippuden & Boruto).  
- A series contains at least one season, although this can be debated for one-shot series (e.g., Death Note).  
- Each season must have at least one episode.

### 👥 Characters-related UML

- In the `SeinenHero` class, the `Accomplished` attribute (float) represents the progress percentage (0.0 to 1.0) of the `Purpose` variable, indicating if the goal is achieved by the end of the series.

---

## 💻 Code

### 🚀 Project Initialization

To initialize the project:  
- Open a terminal in your desired directory.  
- Run `dotnet new console`.  
- Replace the generated `Program.cs` file with the one provided in this repository.  
- Similarly, replace the `ProjetFinalOOM.GlobalUsings.g.cs` file located in `ProjetFinalOOM\obj\Debug\net9.0\` to ensure matching libraries.

### ▶️ Running the Program

- Open a terminal in the `/RenduProjetFinalOOM/ProjetFinalOOM` directory.  
- Run the command `dotnet run`.  
- View program output directly in the console.

---

## 📝 Notes

- Code comments were optimized with AI assistance.  
- Series initializations were supplemented by AI (structure created by me; content provided by AI).
