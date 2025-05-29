use soft_uni;

# Having exercises

# Task 1
SELECT d.name, employees.department_id, SUM(salary) as TotalSalary
FROM employees
         LEFT JOIN soft_uni.departments d on d.department_id = employees.department_id
GROUP BY department_id
HAVING TotalSalary > 15000
;

# Task 2
SELECT e.first_name, name
FROM projects
         LEFT JOIN soft_uni.employees_projects ep on projects.project_id = ep.project_id
         LEFT JOIN soft_uni.employees e on e.employee_id = ep.employee_id
WHERE start_date = '2003-06-01 00:00:00.000000';

# Task 3
SELECT first_name, salary
FROM employees
WHERE employees.manager_id IS NULL
  AND employees.salary > 120000;


# Grouping exercises

# Task 1
SELECT projects.name AS "project-name", d.name as "department-name"
FROM projects
         JOIN soft_uni.employees_projects ep on projects.project_id = ep.project_id
         JOIN soft_uni.employees e on e.employee_id = ep.employee_id
         JOIN soft_uni.departments d on e.department_id = d.department_id
GROUP BY `department-name`
;

# Task 2
SELECT COUNT(name) AS count, TIMESTAMPDIFF(YEAR, start_date, end_date) AS duration
FROM projects
WHERE TIMESTAMPDIFF(YEAR, start_date, end_date) IS NOT NULL
GROUP BY duration
ORDER BY duration;

