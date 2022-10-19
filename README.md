# Автоматизация работы оптовой фирмы

---

![](https://github.com/Vya4eslavSeleznev/WholesaleFirm/docs/warehouse.gif)

---

В качестве языка программирования был использован C#, ADO.NET.

Схема базы данных:

![Db Schema](/docs/db.png)

При запуске приложения, пользователя встречает форма аутентификации, где необходимо ввести логин и пароль:

![Auth](/docs/auth.png)

Затем менеджер попадает на вкладку, где находится информация о складе №1 и №2. На данной вкладке пользователь может завести товар на склад №1 или №2. Более того, можно удалить сразу несколько товаров со складов, нажав кнопки “Delete selected”.:

![Warehouses](/docs/warehouses.png)

Следующая вкладка “Goods” позволяет работать с таблицей товаров:

![Goods](/docs/goods.png)

Менеджер имеет возможность добавлять записи и удалять выбранные товары. При добавлении в программе обновляются все comboBox. На DataGrid доступна кнопка “Edit”, которая позволяет редактировать товары. При нажатии вылетает диалоговое окно:

![Good](/docs/addGood.png)

Чтобы увидеть прогноз спроса на товар, необходимо нажать на кнопку “Forecast demand”. Пользователю необходимо товар и промежуток времени, чтобы увидеть график. Спрос показывается для всех дат в данном промежутке. Более того, присутствует прогноз на следующую неделю. Гистограмма позволяет визуализировать изменение спроса данного товара за некоторый промежуток времени.:

![Demand](/docs/demand.png)

Следующая вкладка “Sales” позволяет работать с таблицей заявок:

![Sales](/docs/sales.png)

Менеджер имеет возможность добавлять записи и удалять выбранные заявки. На DataGrid доступна кнопка “Edit”, которая позволяет редактировать заявки. При нажатии вылетает диалоговое окно. При добавлении заявки товары списываются сначала с первого склада. В случае нехватки товара списание будет происходить со второго склада. При редактировании количество товаров тоже будет изменяться на складах. Добавить заявку с количеством меньше 1 не получится. В базе данных реализованы триггеры, которые контролируют поведение программы:

![Sale](/docs/addSale.png)

Для менеджера необходимо было реализовать вкладку статистики, в которой хранится информация о самых популярных товарах:

![Statistic](/docs/statistic.png)
