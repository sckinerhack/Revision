# Quick Reference Card

## Login Credentials

```
Username: admin
Password: admin
```

## File Locations for Key Features

### Login Feature

- Logic: `Business/LoginBusiness.cs`
- UI: `Views/UCs/UcLogin.xaml`
- Window: `Views/LoginWindow.xaml`

### Navigation Buttons

- Logic: `Business/MainWindowBusiness.cs`
- UI: `Views/MainWindow.xaml`

### Student Management

- Logic: `Business/StudentBusiness.cs` (Add/Edit/Delete commands)
- UI: `Views/UCs/UcGestion.xaml` (Shared with Professor)
- Data: `Models/Student.cs`

### Professor Management

- Logic: `Business/PRofesseurBusiness.cs` (Add/Edit/Delete commands)
- UI: `Views/UCs/UcGestion.xaml` (Shared with Student)
- Data: `Models/Professeur.cs`

### Logout Feature

- Logic: `Business/MainWindowBusiness.cs` → `Logout()` method
- UI: `Views/MainWindow.xaml` → Logout button binding

## Build Command

```powershell
$msbuild = "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
& $msbuild "Revision.csproj" /p:Configuration=Debug
```

## Run Command

```powershell
.\bin\Debug\Revision.exe
```

## Key Classes & Methods

### LoginBusiness

- `Login()` - Validates admin/admin and opens MainWindow
- Properties: Username, Password, ErrorMessage

### StudentBusiness & PRofesseurBusiness

- `AddCommand` - Shows "Add" MessageBox
- `EditCommand` - Shows "Edit" MessageBox
- `DeleteCommand` - Shows "Delete" MessageBox
- `ListOfObjects` - ObservableCollection with 10 fake records

### MainWindowBusiness

- `ShowGestionEtudiant()` - Displays student grid
- `ShowGestionProf()` - Displays professor grid
- `Logout()` - Returns to login screen

## UI Elements Flow

```
App.xaml (StartupUri)
    ↓
LoginWindow.xaml
    ↓
UcLogin.xaml (DataContext: LoginBusiness)
    ↓
    [admin/admin] → Login button → LoginBusiness.Login()
    ↓
MainWindow.xaml (DataContext: MainWindowBusiness)
    ↓
UcGestion.xaml (DataContext: StudentBusiness or PRofesseurBusiness)
    ↓
    [Buttons] → AddCommand/EditCommand/DeleteCommand → MessageBox
```

## Property Binding Examples

```xaml
<!-- Binding to business property -->
<Label Content="{Binding LabelContent}"/>

<!-- Binding to command -->
<Button Command="{Binding GestionEtudiantCommand}"/>

<!-- Binding to text -->
<TextBox Text="{Binding Username, UpdateSourceTrigger=PropertyChanged}"/>
```

## Command Execution Flow

```
User clicks button
    ↓
XAML Command binding triggered
    ↓
Business class method called
    ↓
MessageBox shows (or action performed)
    ↓
No code-behind event handlers needed!
```

## Common Questions

**Q: Where do I add new students?**
A: `StudentBusiness.cs` constructor - add to `ListOfObjects` collection

**Q: How to change login credentials?**
A: `LoginBusiness.cs` → `Login()` method → change "admin" strings

**Q: How to add more buttons?**
A: Add property in Business class, bind in XAML, create command handler

**Q: Why MVVM?**
A: Separates UI from logic, easier to test, easier to modify

**Q: Why use Commands instead of Click events?**
A: Commands are testable, don't require code-behind, follow MVVM pattern

## Troubleshooting

| Issue                                            | Solution                                               |
| ------------------------------------------------ | ------------------------------------------------------ |
| Build fails with "InitializeComponent not found" | Use MSBuild, not dotnet build                          |
| Login button doesn't work                        | Verify exact credentials: admin/admin                  |
| Buttons don't respond                            | Check DataContext is set in XAML                       |
| MessageBox doesn't appear                        | Ensure Command binding exists in XAML                  |
| Window doesn't open                              | Check if window XAML is properly registered in .csproj |

## MVVM Checklist

- ✅ Business logic in Business classes (not UI)
- ✅ UI binds to business properties (not direct code)
- ✅ Commands handle button clicks (not events)
- ✅ Models are plain data objects (no UI logic)
- ✅ Views are just XAML (no code-behind logic)

## Performance Notes

- DataGrid displays 10 records → No performance issues
- All data is in-memory → No database calls
- Bindings are simple → No complex calculations
- Perfect for learning and demonstrations

## Modification Guide

### To Add a New Button

1. Add DelegateCommand property in Business class
2. Initialize in constructor: `new DelegateCommand(MethodName)`
3. Create method to handle action
4. Bind in XAML: `Command="{Binding PropertyName}"`

### To Modify Login Credentials

1. Open `Business/LoginBusiness.cs`
2. Find: `if (Username == "admin" && Password == "admin")`
3. Change strings to new credentials

### To Change Button Labels

1. Open Business class (e.g., `StudentBusiness.cs`)
2. Modify string properties in constructor
3. Labels auto-update in UI via binding

### To Add More Records

1. Open Business class constructor
2. Add more `ListOfObjects.Add()` calls in the for loop
3. DataGrid auto-updates

This is a **self-contained, learning-friendly application**. All code is straightforward and demonstrates core WPF/MVVM concepts!
