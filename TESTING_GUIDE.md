# Testing Guide - WPF Revision Application

## Quick Start

### Build the Project

```powershell
$msbuild = "C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe"
& $msbuild "Revision.csproj" /p:Configuration=Debug
```

### Run the Application

```powershell
.\bin\Debug\Revision.exe
```

## Test Cases

### 1. Login Screen Tests

#### Test 1.1: Valid Login

- **Steps:**
  1. Run application - login window appears
  2. Enter Username: `admin`
  3. Enter Password: `admin`
  4. Click "Login" button
- **Expected Result:** MainWindow opens, login window closes
- **Status:** ✓ PASS

#### Test 1.2: Invalid Username

- **Steps:**
  1. Enter Username: `user`
  2. Enter Password: `admin`
  3. Click "Login" button
- **Expected Result:** Error message "Invalid username or password" appears
- **Status:** ✓ PASS

#### Test 1.3: Invalid Password

- **Steps:**
  1. Enter Username: `admin`
  2. Enter Password: `wrong`
  3. Click "Login" button
- **Expected Result:** Error message "Invalid username or password" appears
- **Status:** ✓ PASS

#### Test 1.4: Empty Fields

- **Steps:**
  1. Leave Username empty
  2. Leave Password empty
  3. Click "Login" button
- **Expected Result:** Error message "Please enter username and password"
- **Status:** ✓ PASS

#### Test 1.5: Partial Empty

- **Steps:**
  1. Enter Username: `admin`
  2. Leave Password empty
  3. Click "Login" button
- **Expected Result:** Error message "Please enter username and password"
- **Status:** ✓ PASS

### 2. Main Window Navigation Tests

#### Test 2.1: Student Management Button

- **Steps:**
  1. Log in successfully
  2. Click "Gestion Etudiant" button
- **Expected Result:**
  - Student DataGrid displays
  - Label shows "GEstion Des etudiants"
  - 10 student records visible
- **Status:** ✓ PASS

#### Test 2.2: Professor Management Button

- **Steps:**
  1. Log in successfully
  2. Click "Gestion Professeur" button
- **Expected Result:**
  - Professor DataGrid displays
  - Label shows "Gestion Des Prof"
  - 10 professor records visible
- **Status:** ✓ PASS

#### Test 2.3: Toggle Between Views

- **Steps:**
  1. Click "Gestion Etudiant"
  2. Click "Gestion Professeur"
  3. Click "Gestion Etudiant" again
- **Expected Result:** DataGrid content changes between students and professors
- **Status:** ✓ PASS

### 3. Button Command Tests

#### Test 3.1: Student Add Button

- **Steps:**
  1. Log in and navigate to "Gestion Etudiant"
  2. Click "Ajouter un étudiant" button
- **Expected Result:** MessageBox shows "Add Student functionality"
- **Status:** ✓ PASS

#### Test 3.2: Student Edit Button

- **Steps:**
  1. Log in and navigate to "Gestion Etudiant"
  2. Click "Modifier un étudiant" button
- **Expected Result:** MessageBox shows "Edit Student functionality"
- **Status:** ✓ PASS

#### Test 3.3: Student Delete Button

- **Steps:**
  1. Log in and navigate to "Gestion Etudiant"
  2. Click "Supprimer un étudiant" button
- **Expected Result:** MessageBox shows "Delete Student functionality"
- **Status:** ✓ PASS

#### Test 3.4: Professor Add Button

- **Steps:**
  1. Log in and navigate to "Gestion Professeur"
  2. Click "Ajouter un Prof" button
- **Expected Result:** MessageBox shows "Add Professeur functionality"
- **Status:** ✓ PASS

#### Test 3.5: Professor Edit Button

- **Steps:**
  1. Log in and navigate to "Gestion Professeur"
  2. Click "Modifier un Prof" button
- **Expected Result:** MessageBox shows "Edit Professeur functionality"
- **Status:** ✓ PASS

#### Test 3.6: Professor Delete Button

- **Steps:**
  1. Log in and navigate to "Gestion Professeur"
  2. Click "Supprimer un Prof" button
- **Expected Result:** MessageBox shows "Delete Professeur functionality"
- **Status:** ✓ PASS

### 4. Logout Tests

#### Test 4.1: Logout Flow

- **Steps:**
  1. Log in with `admin/admin`
  2. Navigate to any section
  3. Click "Logout" button
- **Expected Result:**
  - MainWindow closes
  - LoginWindow appears
  - Can log in again
- **Status:** ✓ PASS

#### Test 4.2: Multiple Login/Logout Cycles

- **Steps:**
  1. Log in → Logout → Log in → Logout
  2. Repeat 3 times
- **Expected Result:** Each cycle works correctly, no crashes
- **Status:** ✓ PASS

## Code Understanding Guide

### Key Files to Review

1. **LoginBusiness.cs** - Simple authentication logic

   - Credentials hardcoded as `admin/admin`
   - Demonstrates MVVM pattern with INotifyPropertyChanged
   - Command handler opens MainWindow on success

2. **StudentBusiness.cs** - Manages student data

   - Observable collection of 10 fake students
   - Button content strings bound to UI
   - Command handlers show MessageBox

3. **PRofesseurBusiness.cs** - Manages professor data

   - Same structure as StudentBusiness
   - Slightly different labels (French: "Prof")

4. **MainWindowBusiness.cs** - Coordinates main window

   - Navigation between student/professor views
   - Logout command returns to login screen

5. **UcLogin.xaml** - Login form UI

   - Username TextBox with binding
   - PasswordBox (manual sync in code-behind)
   - Login button with command binding

6. **UcGestion.xaml** - Data management form
   - Label, three buttons, and DataGrid
   - All bound to business class properties

## Common Issues & Solutions

### Issue: Application won't start

- **Solution:** Ensure MSBuild (not dotnet build) is used
- **Reason:** WPF XAML compilation requires MSBuild

### Issue: Login button doesn't work

- **Solution:** Ensure exact credentials "admin/admin" (case-sensitive)
- **Reason:** Simple string comparison

### Issue: Buttons don't show confirmation

- **Solution:** Ensure DataContext is set correctly in business classes
- **Reason:** Commands must be in the bound business object

### Issue: MessageBox text is truncated

- **Solution:** Normal behavior for MessageBox - drag edges to resize
- **Reason:** MessageBox is not resizable by default

## Learning Points

1. **MVVM Pattern**: Business classes don't reference UI directly
2. **Binding**: Properties change in business → UI updates automatically
3. **Commands**: Button clicks don't have code-behind handlers
4. **DelegateCommand**: Prism framework simplifies command creation
5. **Separation of Concerns**: Logic, Models, and Views are separate

## Next Steps for Development

1. Replace MessageBox with actual database operations
2. Add input validation in CRUD operations
3. Implement proper data persistence
4. Add error handling and logging
5. Create unit tests for business logic
