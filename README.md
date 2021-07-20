# SoftMediaClubTestTask
Руководствовался статьей про чистую архитектуру - https://habr.com/ru/company/mobileup/blog/335382/

Url swagger'а  - `{base_url}/swagger`

# Описание
1) Пытался сделать проект с чистой архитектурой разбив каждый функционал бизнес логики на UseCase(interface)/Interactors(implementation), причем на каждый UseCase только один публичный метод Execute/ExecuteAsync, то есть соблюдается принцип единственной ответственности из SOLID
2) Не стал использовать паттерн "repository" и вместо них использовал абстракции query(select) и commands(insert, update, delete)  
   Это позаимствовал с паттерна cqrs(запросы(query) и команды(command))
3) Каждый слой использует свои модели, слои: controller => useCase => command or query
4) Использовался fluent api для entity framework и fluent validation для валидации данных с апи запросов

# Unit тесты
Написал по одному юнит тесту на каждую категорию тестов, думаю для тестового задания это достаточно

# Структура проекта
1) SoftMediaClubTestTask.Domain - "Core" проект, который будет содержать все основные модели(в том числе и классы таблиц БД), исключения, расширения методов и т.д.
2) SoftMediaClubTestTask.Application - проект, который содержит все нужные интерфейсы(commands, queries и usecases)
3) SoftMediaClubTestTask.Infrastructure - проект, в котором содержатся реализации интерфейсов проект Application, а также инициализация контекста базы данных
4) SoftMediaClubTestTask.API - проект, который является оболочкой для всего solution, это обычный ASP NET Core WEB API, не содержит никакой бизнес логики, использует интерфейсы useCase и делает валидацию входных данных
5) SoftMediaClubTestTask.Tests - общий проект для всех юнит тестов
