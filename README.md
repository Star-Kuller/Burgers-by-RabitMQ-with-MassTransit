Это репозиторий созданный для закрепления навыков работы с MassTransit
За основу я взял другой свой проект [Burgers-by-RabitMQ](https://github.com/Star-Kuller/Burgers-by-RabitMQ) <br/>
В этом репозитории 3 консольных приложения
- OrderTerminal - имитирует микросервис заказов, через консоль этого приложения можно сделать заказ
- Kitchen - имитирует микросервис, который готовит заказы
- NotificationBoard - имитирует микросервис уведомлений

## Как запустить?
Для запуска достаточно открыть корневую директорию проекта и написать <code>docker-compose up</code>, затем нужно запустить OrderTerminal, он поключится к Docker и можно создавать заказы
