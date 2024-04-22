# User Management:
* Users can register and log in to the system.
* Users have roles assigned to them (admin, user, visitor). Only admin and user can have access to the Finance Management and Finance Overview
* Only admin have the access to the **UserManagement** and do modification on the user's data 
# Transaction Management:
* Users can create, view, and edit transactions.
* Each transaction has a timestamp, amount, description, category, and is associated with a specific user (CustomerId).
* Transactions can be of type income or expense, determined by their category.
* Transactions are grouped by year and month and displayed in descending order.
# PartialView & ViewModels 
* PartialView and ViewModels are both widely used through the whole project. 
# Data Visualization:
* The system provides visualizations of transactions data.
* Daily income and expenses for the last 30 days are displayed in a bar chart.
* Monthly savings, expenses, and incomes for the last 12 months are displayed in a combo chart.
# Anti-forgery token validation
* Anti-forgery token is implemented either by asp-help tag or manually to all the used form in the app
# FormValidation:
* Form validation on every form,including .net core highly automated form validation through the asp-tags and "Ajax" driven form also have manually added validation based on the backend's returned JSON obejct
# AJAX Call 
* Instead of the JQuery's AJAX, this app use JS's own Fetch api to achieve the same functionality. 
* Finance Management's both editing and creation's functionality are totally depended on the "AJAX" approach including the from validation is also done by "ajax".
# Data base
* Sqlite and Entity Framework is used for the data storage in this app
# Saving Goal:
* Users can set a saving goal.
* The system calculates the maximum daily expense based on cash flow since the day one of the month ongoing month's left days to meet the saving goal.