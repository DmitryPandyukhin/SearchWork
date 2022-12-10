# SearchWork

### Проект MyStore.sln => MyStore.csproj. Приложение для просмотра, ввода и редактирования сущностей: сотрудники, подразделения, заказы.
#### Стек: WPF, MVVM, SQLite, Entity Framework, INotifyPropertyChanged, IDataErrorInfo, Net6, C#10.
Архив "MyStoreSetup.zip" содержит программу для ознакомления.

### Проект SimpleFigure.sln => SimpleFigure.csproj. Библиотека для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.
#### Cтек: Net6, C#10, MSUnit, статический полиморфизм.
Дополнительно реализовано: 
  - проект тестирования SimpleFigureTest.csproj;
  - метод проверки прямоугольности треугольника.


### SimpleFigure/products.sql. Реализована архитектура БД и sql-запрос по pадаче.
#### Стек: MS SQl Server, SQL.
Задача.
В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.
