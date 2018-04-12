# HandshakesTheory
В данном репозитории представлен код веб-приложения, проверяющеего теорию 6 рукопожатий между профилями в соц.сети VK.

## Содержание
1. [Среда разработки](#Среда-разработки)
2. [О приложении](#О-приложении)
3. [Доступ к ресурсу](#Доступ-к-ресурсу)
4. [Как пользоваться](#Как-пользоваться)
## Среда разработки
При разработке данного приложения были использованы:
Microsoft Visual Studio 2017 Community Edition
IIS Express 10.0

## О приложении
Данное веб-приложение позволяет узнать пользователю через сколько рукопожатий он знаком с интересующим его человеком.

## Доступ к ресурсу
Веб-приложение доступно по адресу: http://handshakes.canadacentral.cloudapp.azure.com

## Как пользоваться
В следующем окне пользователь вводит 2 ID vk.com, между которыми он хочет найти путь из рукопожатий. При этом пользователю отображается информация о корректности данного ID. 
Также необходимо указать максимальную длину пути. Как показывает практика, длина пути между двумя людьми находится в диапазоне от 3 до 7.
Значение максимального пути значительно влияет на время работы алгоритма, поэтому лучше начитать в минимальных значений (3-4) и если связь не найдется - увеличивать.

![alt-text](https://github.com/rokez98/HandshakesTheory/blob/master/Graphics/RequestForm.png?raw=true)

Если пользователь затрудняется в вопросе между кем искать связь, для примера ему приводится короткий список знаметостей, зарегестрированных в VK. 

![alt text](https://github.com/rokez98/HandshakesTheory/blob/master/Graphics/CantChoose.png?raw=true)

Если при заданных параметрах цепочку найти не удаться пользователь увидит следующее уведомление: 

![alt-text](https://github.com/rokez98/HandshakesTheory/blob/master/Graphics/NoLinks.png?raw=true)
