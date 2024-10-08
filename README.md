# Final Project - .NET Application

This project is a .NET-based application, built using WPF (Windows Presentation Foundation). The application structure follows a typical WPF project, with the main components being the XAML-based UI and the accompanying C# code-behind files for business logic and interaction.

## Project Structure

Below is a brief overview of the key files in this repository:

### 1. AssemblyInfo.cs
- Located in the `Properties` folder, this file contains metadata about the assembly, such as title, description, versioning, and company information.
- You can configure version control and other assembly-level attributes here.

**File:** [AssemblyInfo.cs](https://github.com/Justin222993/Final-project-.Net/blob/master/AssemblyInfo.cs)

### 2. App.xaml & App.xaml.cs
- **App.xaml**: Defines the global resources and application-level configurations like styles and themes. It also sets the main entry point of the application.
- **App.xaml.cs**: The code-behind for `App.xaml`. This file handles application-level events such as startup, exit, and unhandled exceptions.

**Files:**
- [App.xaml](https://github.com/Justin222993/Final-project-.Net/blob/master/App.xaml)
- [App.xaml.cs](https://github.com/Justin222993/Final-project-.Net/blob/master/App.xaml.cs)

### 3. MainWindow.xaml & MainWindow.xaml.cs
- **MainWindow.xaml**: This file defines the main user interface layout using XAML (Extensible Application Markup Language). It declares UI components like buttons, text boxes, and other controls.
- **MainWindow.xaml.cs**: The code-behind for `MainWindow.xaml`, containing the interaction logic between the UI and business logic. It handles events triggered by user actions such as button clicks.

**Files:**
- [MainWindow.xaml](https://github.com/Justin222993/Final-project-.Net/blob/master/MainWindow.xaml)
- [MainWindow.xaml.cs](https://github.com/Justin222993/Final-project-.Net/blob/master/MainWindow.xaml.cs)

### 4. TestDB.csproj
This file is the project file for the .NET solution, containing the project’s configurations and references, such as NuGet packages, assembly references, and build targets.

**File:** [TestDB.csproj](https://github.com/Justin222993/Final-project-.Net/blob/master/TestDB.csproj)

### 5. TestDB.sln
This is the solution file for the project, which holds all the projects within the solution. It’s used to load the entire project in IDEs like Visual Studio.

**File:** [TestDB.sln](https://github.com/Justin222993/Final-project-.Net/blob/master/TestDB.sln)

## Prerequisites

- **.NET SDK**: Make sure you have the latest version of .NET SDK installed. You can download it from [here](https://dotnet.microsoft.com/download).
- **Visual Studio**: For ease of development and debugging, use Visual Studio 2019 or later. You can download Visual Studio [here](https://visualstudio.microsoft.com/).

## How to Run

1. Clone the repository:

   ```bash
   git clone https://github.com/Justin222993/Final-project-.Net.git
   ```
2. Restore the necessary packages:
      Open the solution file TestDB.sln in Visual Studio.
3. Restore the necessary packages:
  ```bash
   dotnet restore
  ```
4. Build the solution using Visual Studio or the .NET CLI:
  ```bash
   dotnet build
  ```
5. Run the application:
   ```bash
   dotnet run
