# Описание работы LinkedListVector и связных списков

## Что такое связный список

**Связный список (Linked List)** — это структура данных, состоящая из узлов (Node), где каждый узел содержит:
- **Данные (Data)** — хранимое значение
- **Ссылку (Next)** — указатель на следующий узел в последовательности

В отличие от массива, элементы связного списка не хранятся в памяти последовательно. Каждый элемент "знает" только о следующем через ссылку.

### Визуальное представление

```
head → [Data: 5 | Next] → [Data: 10 | Next] → [Data: 15 | Next] → null
```

## Структура класса LinkedListVector

### Внутренний класс Node

```csharp
public class Node
{
    public int Data;      // Хранимое целочисленное значение
    public Node? Next;    // Ссылка на следующий узел (может быть null)
    
    public Node(int data = 0, Node? next = null)
    {
        Data = data;
        Next = next;
    }
}
```

Класс `Node` представляет собой отдельный элемент списка. Знак `?` после типа `Node` означает, что ссылка может быть `null` (nullable-тип).

### Поле head

```csharp
private Node? head;
```

`head` — это ссылка на первый узел списка. Если `head == null`, список пуст.

## Конструкторы

### Конструктор по умолчанию

```csharp
public LinkedListVector()
{
    head = null;
    for (int i = 0; i < 5; i++)
    {
        AddToEnd(0);
    }
}
```

Создает список из 5 элементов, каждый инициализирован нулем.

### Конструктор с параметром

```csharp
public LinkedListVector(int length)
{
    if (length <= 0)
    {
        throw new ArgumentException("Длина списка должна быть больше 0");
    }
    head = null;
    for (int i = 0; i < length; i++)
    {
        AddToEnd(0);
    }
}
```

Создает список из `length` элементов. Выбрасывает исключение, если длина ≤ 0.

## Свойства

### Length

```csharp
public int Length
{
    get
    {
        int count = 0;
        Node? current = head;
        while (current != null)
        {
            count++;
            current = current.Next;
        }
        return count;
    }
}
```

**Функция:** Вычисляет и возвращает количество элементов в списке.

**Алгоритм:**
1. Начинаем с `head`
2. Идем по цепочке узлов, пока не достигнем `null`
3. Считаем количество узлов

**Сложность:** O(n), где n — количество элементов

## Основные методы

### 1. GetNode(int index)

```csharp
private Node GetNode(int index)
{
    Node? current = head;
    for (int i = 0; i < index; i++)
    {
        current = current!.Next;
    }
    return current!;
}
```

**Функция:** Возвращает узел по индексу (индексация с 0).

**Алгоритм:** Проходит `index` шагов от `head`.

**Сложность:** O(index)

### 2. Индексатор this[int position]

```csharp
public int this[int position]
{
    get { /* получение значения */ }
    set { /* установка значения */ }
}
```

**Функция:** Обеспечивает доступ к элементам по позиции (нумерация с 1, не с 0!)

**Пример использования:**
```csharp
LinkedListVector vector = new LinkedListVector(3);
vector[1] = 10;  // Устанавливаем первый элемент
int value = vector[2];  // Читаем второй элемент
```

**Важно:** Позиции начинаются с 1, а не с 0. Это отличается от стандартной индексации C#.

**Сложность:** O(position)

### 3. AddToBeginning(int value)

```csharp
public void AddToBeginning(int value)
{
    Node newNode = new Node(value, head);
    head = newNode;
}
```

**Функция:** Добавляет элемент в начало списка.

**Алгоритм:**
1. Создаем новый узел
2. Его `Next` указывает на текущий `head`
3. Обновляем `head` на новый узел

**Визуализация:**
```
До:   head → [5] → [10] → null
После: head → [3] → [5] → [10] → null  (добавили 3)
```

**Сложность:** O(1) — очень быстро!

### 4. AddToEnd(int value)

```csharp
public void AddToEnd(int value)
{
    Node newNode = new Node(value);
    if (head == null)
    {
        head = newNode;
        return;
    }
    Node current = head;
    while (current.Next != null)
    {
        current = current.Next;
    }
    current.Next = newNode;
}
```

**Функция:** Добавляет элемент в конец списка.

**Алгоритм:**
1. Создаем новый узел
2. Если список пуст, новый узел становится `head`
3. Иначе проходим до последнего узла
4. Присоединяем новый узел к последнему

**Визуализация:**
```
До:   head → [5] → [10] → null
После: head → [5] → [10] → [7] → null  (добавили 7)
```

**Сложность:** O(n) — нужно пройти весь список

### 5. AddAtPosition(int position, int value)

```csharp
public void AddAtPosition(int position, int value)
{
    // Проверка границ
    if (position == 1)
    {
        AddToBeginning(value);
        return;
    }
    Node prev = GetNode(position - 2);
    Node newNode = new Node(value, prev.Next);
    prev.Next = newNode;
}
```

**Функция:** Вставляет элемент на указанную позицию (с 1).

**Алгоритм:**
1. Находим узел перед позицией вставки
2. Создаем новый узел, его `Next` → следующий узел
3. Предыдущий узел теперь указывает на новый

**Визуализация:**
```
До:   head → [5] → [10] → [15] → null
      Вставляем 7 на позицию 2
После: head → [5] → [7] → [10] → [15] → null
```

**Сложность:** O(position)

### 6. RemoveFromBeginning()

```csharp
public int RemoveFromBeginning()
{
    if (head == null)
    {
        throw new InvalidOperationException("Список пуст");
    }
    int value = head.Data;
    head = head.Next;
    return value;
}
```

**Функция:** Удаляет и возвращает первый элемент.

**Алгоритм:**
1. Сохраняем значение первого узла
2. Перемещаем `head` на следующий узел
3. Первый узел становится недоступным (будет удален сборщиком мусора)

**Визуализация:**
```
До:   head → [5] → [10] → [15] → null
После: head → [10] → [15] → null  (удалили 5)
```

**Сложность:** O(1)

### 7. RemoveFromEnd()

```csharp
public int RemoveFromEnd()
{
    if (head == null)
    {
        throw new InvalidOperationException("Список пуст");
    }
    if (head.Next == null)
    {
        int val = head.Data;
        head = null;
        return val;
    }
    Node current = head;
    while (current.Next!.Next != null)
    {
        current = current.Next;
    }
    int value = current.Next.Data;
    current.Next = null;
    return value;
}
```

**Функция:** Удаляет и возвращает последний элемент.

**Алгоритм:**
1. Находим предпоследний узел
2. Сохраняем значение последнего узла
3. Обнуляем ссылку `Next` у предпоследнего узла

**Визуализация:**
```
До:   head → [5] → [10] → [15] → null
После: head → [5] → [10] → null  (удалили 15)
```

**Сложность:** O(n)

### 8. RemoveAtPosition(int position)

```csharp
public int RemoveAtPosition(int position)
{
    // Проверки границ
    if (position == 1)
    {
        return RemoveFromBeginning();
    }
    Node prev = GetNode(position - 2);
    int value = prev.Next!.Data;
    prev.Next = prev.Next.Next;
    return value;
}
```

**Функция:** Удаляет и возвращает элемент на позиции.

**Алгоритм:**
1. Находим узел перед удаляемым
2. Сохраняем значение удаляемого узла
3. "Перешагиваем" через удаляемый узел

**Визуализация:**
```
До:   head → [5] → [10] → [15] → null
      Удаляем позицию 2
После: head → [5] → [15] → null  (удалили 10)
```

**Сложность:** O(position)

### 9. GetNorm()

```csharp
public double GetNorm()
{
    double sum = 0;
    Node? current = head;
    while (current != null)
    {
        sum += (double)current.Data * current.Data;
        current = current.Next;
    }
    return Math.Sqrt(sum);
}
```

**Функция:** Вычисляет евклидову норму вектора.

**Формула:** ||v|| = √(x₁² + x₂² + ... + xₙ²)

**Пример:** Для вектора [3, 4], норма = √(9 + 16) = √25 = 5

**Сложность:** O(n)

### 10. Print()

```csharp
public void Print()
{
    Console.Write("[ ");
    Node? current = head;
    while (current != null)
    {
        Console.Write(current.Data + " ");
        current = current.Next;
    }
    Console.WriteLine("]");
}
```

**Функция:** Выводит все элементы списка на консоль.

**Формат вывода:** `[ elem1 elem2 elem3 ]`

**Сложность:** O(n)

## Сравнение со массивом

| Операция | Связный список | Массив |
|----------|---------------|---------|
| Доступ по индексу | O(n) | O(1) ⚡ |
| Вставка в начало | O(1) ⚡ | O(n) |
| Вставка в конец | O(n) | O(1)* |
| Удаление из начала | O(1) ⚡ | O(n) |
| Удаление из конца | O(n) | O(1)* |
| Память | Больше (ссылки) | Меньше |
| Размер | Динамический | Фиксированный** |

*Для динамических массивов (List<T>)  
**Массивы C# фиксированного размера, List<T> — динамический

## Преимущества связного списка

1. **Динамический размер** — можно добавлять элементы без ограничений
2. **Эффективная вставка/удаление в начале** — O(1)
3. **Не требует непрерывной памяти** — элементы могут быть разбросаны
4. **Легкая реорганизация** — можно перестраивать структуру, меняя ссылки

## Недостатки связного списка

1. **Медленный доступ по индексу** — O(n) вместо O(1)
2. **Дополнительная память** — нужны ссылки на следующий элемент
3. **Не кеш-френдли** — элементы не рядом в памяти
4. **Нет обратного обхода** — можно идти только вперед (односвязный список)

## Особенности данной реализации

### 1. Индексация с 1
В отличие от стандартной индексации C# (с 0), здесь позиции начинаются с 1:
```csharp
vector[1]  // первый элемент
vector[2]  // второй элемент
```

### 2. Nullable-ссылки
Использование `Node?` повышает безопасность кода:
```csharp
Node? current = head;  // может быть null
```

### 3. Проверки границ
Все операции проверяют корректность индексов:
```csharp
if (position < 1 || position > Length)
{
    throw new IndexOutOfRangeException("Индекс вне границ списка");
}
```

### 4. Обработка исключений
Операции на пустом списке выбрасывают исключения:
```csharp
if (head == null)
{
    throw new InvalidOperationException("Список пуст");
}
```

## Примеры использования

### Создание и заполнение

```csharp
LinkedListVector vector = new LinkedListVector(3);
vector[1] = 5;
vector[2] = 10;
vector[3] = 15;
vector.Print();  // [ 5 10 15 ]
```

### Добавление элементов

```csharp
vector.AddToBeginning(1);    // [ 1 5 10 15 ]
vector.AddToEnd(20);         // [ 1 5 10 15 20 ]
vector.AddAtPosition(3, 7);  // [ 1 5 7 10 15 20 ]
```

### Удаление элементов

```csharp
int first = vector.RemoveFromBeginning();  // удалили 1
int last = vector.RemoveFromEnd();         // удалили 20
int middle = vector.RemoveAtPosition(2);   // удалили 7
// Итог: [ 5 10 15 ]
```

### Вычисление нормы

```csharp
LinkedListVector v = new LinkedListVector(2);
v[1] = 3;
v[2] = 4;
double norm = v.GetNorm();  // 5.0 (так как √(9+16) = 5)
```

## Когда использовать связный список

**Используйте связный список, если:**
- Часто добавляете/удаляете элементы в начале
- Размер данных неизвестен или часто меняется
- Редко обращаетесь к элементам по индексу
- Часто вставляете элементы в середину

**Используйте массив/List<T>, если:**
- Часто читаете элементы по индексу
- Размер данных известен или почти не меняется
- Нужна производительность при случайном доступе
- Важна кеш-локальность данных

## Заключение

Связный список LinkedListVector — это базовая структура данных, которая демонстрирует принципы работы со ссылками и динамическими структурами. Она эффективна для определенных операций (вставка в начало), но имеет свои ограничения (медленный доступ по индексу).

В реальных проектах C# обычно используют встроенные классы:
- `List<T>` — динамический массив
- `LinkedList<T>` — двусвязный список (можно ходить в обе стороны)

Однако понимание работы связного списка критически важно для освоения алгоритмов и структур данных!
