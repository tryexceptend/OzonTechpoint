# 4. Битва за кондиционер (2 решения)

> Ограничение по времени: 2000 Мс

> Ограничение по памяти: 512 Мб

## Ниже перечислены технические требования к решениям:
- решение читает входные данные со стандартного ввода (экрана);
- решение пишет выходные данные на стандартный вывод (экран);
- решение не взаимодействует как-либо с другими ресурсами компьютера (сеть, жесткий диск, процессы и прочее);
- решение использует только стандартную библиотеку языка;
- решение располагается в пакете по-умолчанию (или его аналоге для вашего языка), имеют стандартную точку входа для консольных программ;
- гарантируется, что во всех тестах выполняются все ограничения, что содержатся в условии задачи — как-либо проверять входные данные на корректность не надо, все тесты строго соответствуют описанному в задаче формату;
- выводи ответ в точности в том формате, как написано в условии задачи (не надо выводить <<поясняющих>> комментариев типа "введите число" или "ответ равен");

## Условие задачи

В офисе стоит кондиционер, на котором можно установить температуру от 15 до 30 градусов.

В офис по очереди приходят n сотрудников. i-й из них желает температуру не больше или не меньше a<sub>i</sub>.

После прихода каждого сотрудника определите, можно ли выставить температуру, которая удовлетворит всех в офисе.

## Входные данные

Каждый тест состоит из нескольких наборов входных данных. Первая строка содержит целое число t (1≤t≤10<sup>3</sup>) — количество наборов входных данных. Далее следует описание наборов входных данных.

Первая строка каждого набора содержит целое число n (1≤n≤10<sup>3</sup>) — количество сотрудников.

i -я из следующих n строк каждого набора входных данных содержит требование к температуре от i-го сотрудника: либо ≥ a<sub>i</sub>​, либо ≤a<sub>i</sub> (15≤a<sub>i</sub>≤30, a<sub>i</sub> — целое число). Требование ≥a<sub>i</sub> означает, что i-й сотрудник желает температуру не ниже a<sub>i</sub>; требование a<sub>i</sub> означает, что i-й сотрудник желает температуру не выше a<sub>i</sub>.

Гарантируется, что сумма n по всем наборам входных данных не превосходит 10<sup>3</sup>.

## Выходные данные

Для каждого набора входных данных выведите n строк, i-я из которых содержит температуру, удовлетворяющую всех сотрудников с номерами от 1 до i включительно. Если такой температуры не существует, выведите −1. После вывода ответа на очередной набор входных данных выводите пустую строку.

Если ответов несколько, выведите любой.

Пояснение к первому примеру:

1. добавляется требование ≥30, диапазон возможных температур — [30, 30], поэтому единственный возможный ответ — 30 градусов.

Пояснение ко второму примеру:

1. добавляется требование ≥18, диапазон возможных температур — [18, 30], поэтому в качестве примера взяли 29 градусов;

2. добавляется требование ≤23, диапазон возможных температур — [18, 23], поэтому в качестве примера взяли 19 градусов;

3. добавляется требование ≥20, диапазон возможных температур — [20, 23], поэтому в качестве примера взяли 22 градуса;

4. добавляется требование ≤27, диапазон возможных температур — [20, 23], поэтому в качестве примера взяли 21 градус;

5. добавляется требование ≤21, диапазон возможных температур —[20, 21], поэтому в качестве примера взяли 20 градусов;

6. добавляется требование ≥28, диапазон возможных температур — [28, 21], поэтому ответа нет и нужно вывести -1.

Пояснение к третьему примеру:

1. добавляется требование ≤25, диапазон возможных температур — [15, 25], поэтому в качестве примера взяли 23 градуса;

2. добавляется требование ≥20, диапазон возможных температур — [20, 25], поэтому в качестве примера взяли 22 градуса;

3. добавляется требование ≥25, диапазон возможных температур — [25, 25], поэтому в качестве примера можно взять только 25 градусов.

Пояснение к четвертому примеру:

1. добавляется требование ≤15, диапазон возможных температур — [15, 15], поэтому в качестве примера можно взять только 15 градусов;

2. добавляется требование ≥30, диапазон возможных температур — [30, 15], поэтому ответа нет и нужно вывести -1;

3. добавляется требование ≤24, диапазон возможных температур — [30, 15], поэтому ответа нет и нужно вывести -1.

## Пример теста 1

### Входные данные

```
4
1
>= 30
6
>= 18
<= 23
>= 20
<= 27
<= 21
>= 28
3
<= 25
>= 20
>= 25
3
<= 15
>= 30
<= 24
```

### Выходные данные

```
30

18
18
20
20
20
-1

15
20
25

15
-1
-1
```
