
List<int> list = new List<int>() { 1, 2, 3, 4, 5 };

void Sum(out int a)
{
    a++;
}

void DoSomething(List<int> list)
{
    for (int i = 0; i < list.Count; i++)
    {
        Sum(list[i]);
    }
}


DoSomething(list);

