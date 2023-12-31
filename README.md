# BookStore

## Тестовое задание WebAPI приложение магазина книг

### Функционал Web API
1. Получение списка всех книг, в т.ч. фильтрация в порядке возрастания/убывания наименования или даты (**Примеры запросов**: nameAsc, nameDesc, releaseAsc, releaseDesc), фильтр по дате(mm/dd/YYYY) и/или названию
2. Получение определенной книги по айди
3. Создание книги
4. Удаление книги
5. Получение списка заказов по фильтру (номер заказа, дата (mm/dd/YYYY))
6. Создание заказа со спиком книг
7. Получение определенного заказа

### Используемые технологии
- .NET 7
- ASP.NET Web API
- Microsoft Entity Framework Core
- MS SQL
- AutoMapper
- Swagger

### Архитектура

#### Структура иерархии папок
Приложение организовано по структурированной иерархии, следуя принципам чистой и N-Layer архитектуре. Разделение на слои, такие как контроллеры, бизнес-логика и доступ к данным, позволяет обеспечить четкую и эффективную организацию кода.

#### База данных
Для хранения данных о книгах и заказах используется база данных Microsoft SQL Server. Приложение использует подход Code-First и миграции Entity Framework Core, что позволяет автоматически создавать и обновлять структуру базы данных на основе определений сущностей.

#### Паттерн Repository и Unit of Work
Для доступа к данным используется паттерн Repository, который позволяет абстрагироваться от конкретных источников данных и обеспечивает единый интерфейс для работы с данными. Паттерн Unit of Work обеспечивает целостность транзакций и управление сессиями при работе с базой данных.

#### Middleware
Приложение использует middleware для обработки исключений. Это позволяет обрабатывать ошибки единообразно и предоставлять пользователю информативные сообщения об ошибках.

#### Mapper
Чтобы обеспечить разделение между сущностями и дто моделями, используется библиотека маппинга данных AutoMapper. Это позволяет преобразовывать данные из сущностей базы данных в модели для передачи через API.

### Документация Swagger
API приложение документируется с использованием инструмента Swagger. Это позволяет легко ознакомиться с доступными методами, параметрами и моделями данных, а также выполнять тестирование API прямо из интерфейса Swagger.