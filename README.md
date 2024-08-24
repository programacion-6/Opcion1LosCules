# Opcion1LosCules
Integrantes:
- Jhael Arce Chavez
- Cristian Sebastian Barra Zurita 
- Diego Centella Lopez
- Emanuel Galindo Corpa 
# Library Management System

## Project Overview:
The goal of the project is to develop a console application for library management. The application should allow the management of a collection of books, library members, and loan transactions. The system should support the management of books and users, handle the loan process, and provide various reports and queries.

## Requirements:

### 1. Book Management:
**Features:**
- Add, update, and delete books from the collection.
- Book properties: title, author, ISBN, genre, and year of publication.
- Categorize books by genre and list books by genre.

**Objective:** Facilitate efficient administration of the library's books.

### 2. Patron Management:
**Features:**
- Manage patron information: name, membership number, and contact details.
- Allow patrons to borrow and return books.

**Objective:** Maintain a detailed record of members and their interactions with books.

### 3. Loan System:
**Features:**
- Mechanism for handling the borrowing and returning of books.
- Track which books are loaned, who borrowed them, and return dates.
- Check book availability and prevent double loans.

**Objective:** Ensure accurate and orderly management of book loans.

### 4. Search and Reports:
**Features:**
- Search for books by title, author, or ISBN.
- Search for patrons by name or membership number.
- Generate reports, such as:
  - List of all currently loaned books.
  - Overdue books.
  - Loan history of a specific patron.

**Objective:** Facilitate the retrieval of information and tracking of library management.

### 5. User Interface:
**Features:**
- Create a user-friendly console interface that guides users through available functionalities.
- Clear instructions and intuitive feedback.

**Objective:** Provide a simple and efficient user experience.

### 6. Error Handling and Validation:
**Features:**
- Implement robust error handling to ensure system stability.
- Input validation to guarantee accurate data and prevent errors.

**Objective:** Ensure that the system is reliable and resilient to common issues.

---

## Branch Naming Convention

### Category
- `feature`: For adding, refactoring, or removing a feature.
- `bugfix`: For fixing a bug.
- `hotfix`: For quick changes or temporary solutions, usually in emergency situations.
- `test`: For experimentation outside of an issue/ticket.
- `docs`: For adding or modifying documentation.
- `refactor`: For refactoring code.

### Reference
- After the category, include a forward slash `/` followed by the reference of the issue/ticket you are working on (e.g., `issue-42`).
- If there's no reference, use `no-ref`.

### Description
- Add another forward slash `/` followed by a short description summarizing the branch's purpose. Use `kebab-case` for this description (words separated by hyphens).

### General Pattern
    git branch <category>/<reference>/<description-in-kebab-case>

### Examples:
- For a new feature: `git branch feature/issue-42/create-new-button-component`
- For fixing a bug: `git branch bugfix/issue-342/button-overlap-form-on-mobile`
- For a quick fix: `git branch hotfix/no-ref/registration-form-not-working`
- For experimentation: `git branch test/no-ref/refactor-components-with-atomic-design`

---

## Commit Naming Convention

### Category
- `feat`: For adding a new feature.
- `fix`: For fixing a bug.
- `refactor`: For code changes that improve performance or readability.
- `chore`: For general tasks (documentation, formatting, cleaning up code, etc.).

### Description
- After the category, include a colon `:` followed by a short description of the changes.
- Statements should be brief, start with an imperative verb, and be separated by a semicolon `;`.

### General Pattern
    git commit -m '<category>: do something; do some other things>'

### Examples:
- `git commit -m 'feat: implement user authentication'`
- `git commit -m 'fix: resolve null pointer exception in user service'`
- `git commit -m 'refactor: optimize database queries'`
- `git commit -m 'chore: update README with setup instructions; clean up obsolete code'`

---

## Pull Request Conventions

### 1. Descriptive Title:
**Format:** `[Type] Brief description of the change made`
- Examples:
  - `[Feature] Implementation of advanced search in the inventory system`
  - `[Fix] Bug fix in product data validation`

### 2. PR Description:
- **Context:** Briefly explain the problem or need that initiated this PR.
- **What was done:** List the changes made clearly and concisely.
  - Example: `- Added search functionality by product name and code.`
- **Purpose:** Detail the goal or value that these changes bring to the project.
  - Example: `- Improve the user experience by facilitating the search for specific products.`

### 3. Relevant Links:
- Include a link to the Trello card, Jira ticket, or any other relevant task management tool.
  - Example: `[Trello #1234](https://trello.com/c/example)`

### Example Pull Request
**Title:** `[Feature] Add category filter functionality to the search system`
**Description:**
- **Context:** Users need to filter products by category to improve search efficiency.
- **What was done:**
  - Implemented a new category filter in the product search.
  - Updated the user interface to include a category selector.
  - Added unit tests to cover the new filter.
- **Purpose:**
  - This change allows users to find products more efficiently by filtering by category, improving the system's usability.
- **Relevant Links:**
  - `Trello #5678`

---

## Git Flow Conventions 

### Main Branches:
- `main`: Contains the stable version of the code in production. Merges from `develop` occur when the code is ready for deployment.
- `develop`: Integration branch for development. Feature and hotfix branches are merged here (if there are critical bugs).

### 2. Support Branches:
- `feature/{name}`: Used for developing new features or improvements. This branch is created from `develop` and merged back into `develop` once completed.
  - Example: `feature/implement-search`

### 3. Workflow:
**Creating Branches:**
- For new features, create a feature branch from `develop`.
- Command: `git checkout -b feature/new-feature develop`

**Merging:**
- Feature branches are merged into `develop` when complete.
- Command: `git checkout develop` then `git merge feature/new-feature`
- When the code in `develop` is ready for production, merge it into `main`.
- Command: `git checkout main` then `git merge develop`



