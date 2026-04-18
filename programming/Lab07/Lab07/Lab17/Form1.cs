using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Lab17
{
    public partial class Form1 : Form
    {
        private readonly TabControl tabs = new TabControl();

        private ArrayVector av1, av2;
        private TextBox tbAvInput1, tbAvInput2, tbAvVecNum, tbAvIndex, tbAvValue;
        private Label lbAvResult;

        private LinkedListVector ll;
        private TextBox tbLlInput, tbLlIndex, tbLlValue;
        private Label lbLlResult;

        private TextBox tbMixInput1, tbMixInput2;
        private Label lbMixResult;

        private IVectorable[] vectors;
        private TextBox tbAovCount, tbAovType, tbAovInput, tbAovIdx1, tbAovIdx2, tbAovCloneIdx, tbAovEditIdx, tbAovEditVal;
        private Label lbAovResult;
        private int aovAddPos = 0;

        private ArrayVector stVec;
        private TextBox tbStInput;
        private Label lbStResult;

        public Form1()
        {
            Text = "Lab17";
            Width = 1100;
            Height = 760;
            StartPosition = FormStartPosition.CenterScreen;

            tabs.Dock = DockStyle.Fill;
            Controls.Add(tabs);

            BuildArrayPage();
            BuildLinkedListPage();
            BuildMixedSumPage();
            BuildArrayOfVectorsPage();
            BuildStreamsPage();
        }

        private static int ToInt(string s, int def = 0) => int.TryParse(s, out int x) ? x : def;

        private void BuildArrayPage()
        {
            var p = new TabPage("ArrayVector");

            p.Controls.Add(new Label { Left = 20, Top = 20, Width = 180, Text = "Вектор 1 (через пробел):" });
            tbAvInput1 = new TextBox { Left = 210, Top = 16, Width = 760, Height = 30 };

            p.Controls.Add(new Label { Left = 20, Top = 58, Width = 180, Text = "Вектор 2 (через пробел):" });
            tbAvInput2 = new TextBox { Left = 210, Top = 54, Width = 760, Height = 30 };

            var bCreate = new Button { Left = 20, Top = 95, Width = 190, Height = 32, Text = "Создать из строк" };

            p.Controls.Add(new Label { Left = 230, Top = 102, Width = 130, Text = "Номер вектора:" });
            tbAvVecNum = new TextBox { Left = 360, Top = 98, Width = 55, Height = 30, Text = "1" };

            p.Controls.Add(new Label { Left = 430, Top = 102, Width = 60, Text = "Индекс:" });
            tbAvIndex = new TextBox { Left = 490, Top = 98, Width = 70, Height = 30, Text = "0" };

            p.Controls.Add(new Label { Left = 575, Top = 102, Width = 75, Text = "Значение:" });
            tbAvValue = new TextBox { Left = 650, Top = 98, Width = 80, Height = 30, Text = "0" };

            var bFill = new Button { Left = 20, Top = 140, Width = 120, Height = 34, Text = "Заполнить" };
            var bShow = new Button { Left = 150, Top = 140, Width = 120, Height = 34, Text = "Вывести" };
            var bNorm = new Button { Left = 280, Top = 140, Width = 120, Height = 34, Text = "Норма" };
            var bLen = new Button { Left = 410, Top = 140, Width = 120, Height = 34, Text = "Длина" };
            var bGet = new Button { Left = 540, Top = 140, Width = 120, Height = 34, Text = "Получить" };
            var bSet = new Button { Left = 670, Top = 140, Width = 120, Height = 34, Text = "Изменить" };
            var bSum = new Button { Left = 800, Top = 140, Width = 80, Height = 34, Text = "Сумма" };
            var bSc = new Button { Left = 890, Top = 140, Width = 80, Height = 34, Text = "Скаляр" };

            var bNormStatic = new Button { Left = 20, Top = 180, Width = 220, Height = 34, Text = "Норма (static)" };

            lbAvResult = new Label { Left = 20, Top = 225, Width = 1000, Height = 420 };

            p.Controls.Add(tbAvInput1); p.Controls.Add(tbAvInput2);
            p.Controls.Add(bCreate);
            p.Controls.Add(tbAvVecNum); p.Controls.Add(tbAvIndex); p.Controls.Add(tbAvValue);
            p.Controls.Add(bFill); p.Controls.Add(bShow); p.Controls.Add(bNorm); p.Controls.Add(bLen);
            p.Controls.Add(bGet); p.Controls.Add(bSet); p.Controls.Add(bSum); p.Controls.Add(bSc); p.Controls.Add(bNormStatic);
            p.Controls.Add(lbAvResult);

            bCreate.Click += (s, e) =>
            {
                try
                {
                    av1 = VectorInputHelper.ParseArrayVector(tbAvInput1.Text);
                    av2 = VectorInputHelper.ParseArrayVector(tbAvInput2.Text);
                    lbAvResult.Text = $"Вектор 1: {av1}\nВектор 2: {av2}";
                }
                catch (Exception ex) { lbAvResult.Text = ex.Message; }
            };

            bFill.Click += (s, e) =>
            {
                if (!EnsureAV()) return;
                var v = GetAvByNum();
                if (v == null) return;
                FillVectorDialog(v);
                lbAvResult.Text = "Заполнено: " + v;
            };

            bShow.Click += (s, e) => { if (!EnsureAV()) return; var v = GetAvByNum(); if (v != null) lbAvResult.Text = v.ToString(); };
            bNorm.Click += (s, e) => { if (!EnsureAV()) return; var v = GetAvByNum(); if (v != null) lbAvResult.Text = "Норма: " + v.GetNorm(); };
            bLen.Click += (s, e) => { if (!EnsureAV()) return; var v = GetAvByNum(); if (v != null) lbAvResult.Text = "Длина: " + v.Length; };

            bGet.Click += (s, e) =>
            {
                if (!EnsureAV()) return;
                var v = GetAvByNum(); if (v == null) return;
                int idx = ToInt(tbAvIndex.Text);
                try { lbAvResult.Text = $"Элемент [{idx}] = {v[idx]}"; } catch (Exception ex) { lbAvResult.Text = ex.Message; }
            };

            bSet.Click += (s, e) =>
            {
                if (!EnsureAV()) return;
                var v = GetAvByNum(); if (v == null) return;
                int idx = ToInt(tbAvIndex.Text);
                int val = ToInt(tbAvValue.Text);
                try { v[idx] = val; lbAvResult.Text = "После изменения: " + v; } catch (Exception ex) { lbAvResult.Text = ex.Message; }
            };

            bSum.Click += (s, e) => { if (!EnsureAV()) return; try { lbAvResult.Text = "Сумма: " + Vectors.SumSt(av1, av2); } catch (Exception ex) { lbAvResult.Text = ex.Message; } };
            bSc.Click += (s, e) => { if (!EnsureAV()) return; try { lbAvResult.Text = "Скалярное: " + Vectors.ScalarSt(av1, av2); } catch (Exception ex) { lbAvResult.Text = ex.Message; } };
            bNormStatic.Click += (s, e) => { if (!EnsureAV()) return; var v = GetAvByNum(); if (v != null) lbAvResult.Text = "Норма (static): " + Vectors.GetNormSt(v); };

            tabs.TabPages.Add(p);
        }

        private bool EnsureAV()
        {
            if (av1 == null || av2 == null) { lbAvResult.Text = "Сначала создай оба вектора"; return false; }
            return true;
        }

        private ArrayVector GetAvByNum()
        {
            int n = ToInt(tbAvVecNum.Text, 1);
            if (n == 1) return av1;
            if (n == 2) return av2;
            lbAvResult.Text = "Номер вектора должен быть 1 или 2";
            return null;
        }

        private void BuildLinkedListPage()
        {
            var p = new TabPage("LinkedListVector");

            p.Controls.Add(new Label { Left = 20, Top = 20, Width = 180, Text = "Вектор (через пробел):" });
            tbLlInput = new TextBox { Left = 210, Top = 16, Width = 760, Height = 30 };

            var bCreate = new Button { Left = 20, Top = 55, Width = 190, Height = 32, Text = "Создать из строки" };

            p.Controls.Add(new Label { Left = 230, Top = 62, Width = 130, Text = "Индекс/позиция:" });
            tbLlIndex = new TextBox { Left = 360, Top = 58, Width = 70, Height = 30, Text = "0" };

            p.Controls.Add(new Label { Left = 445, Top = 62, Width = 70, Text = "Значение:" });
            tbLlValue = new TextBox { Left = 520, Top = 58, Width = 80, Height = 30, Text = "0" };

            var bFill = new Button { Left = 20, Top = 100, Width = 120, Height = 34, Text = "Заполнить" };
            var bShow = new Button { Left = 150, Top = 100, Width = 120, Height = 34, Text = "Вывести" };
            var bNorm = new Button { Left = 280, Top = 100, Width = 120, Height = 34, Text = "Норма" };
            var bLen = new Button { Left = 410, Top = 100, Width = 120, Height = 34, Text = "Длина" };
            var bGet = new Button { Left = 540, Top = 100, Width = 120, Height = 34, Text = "Получить" };
            var bSet = new Button { Left = 670, Top = 100, Width = 120, Height = 34, Text = "Изменить" };

            var bAddEnd = new Button { Left = 20, Top = 140, Width = 160, Height = 34, Text = "Добавить в конец" };
            var bAddBeg = new Button { Left = 190, Top = 140, Width = 160, Height = 34, Text = "Добавить в начало" };
            var bAddAt = new Button { Left = 360, Top = 140, Width = 180, Height = 34, Text = "Добавить в позицию" };
            var bRemEnd = new Button { Left = 550, Top = 140, Width = 160, Height = 34, Text = "Удалить из конца" };
            var bRemBeg = new Button { Left = 720, Top = 140, Width = 160, Height = 34, Text = "Удалить из начала" };
            var bRemAt = new Button { Left = 890, Top = 140, Width = 130, Height = 34, Text = "Удалить позицию" };

            lbLlResult = new Label { Left = 20, Top = 210, Width = 1000, Height = 435 };

            p.Controls.Add(tbLlInput); p.Controls.Add(bCreate);
            p.Controls.Add(tbLlIndex); p.Controls.Add(tbLlValue);
            p.Controls.Add(bFill); p.Controls.Add(bShow); p.Controls.Add(bNorm); p.Controls.Add(bLen); p.Controls.Add(bGet); p.Controls.Add(bSet);
            p.Controls.Add(bAddEnd); p.Controls.Add(bAddBeg); p.Controls.Add(bAddAt); p.Controls.Add(bRemEnd); p.Controls.Add(bRemBeg); p.Controls.Add(bRemAt);
            p.Controls.Add(lbLlResult);

            bCreate.Click += (s, e) =>
            {
                try
                {
                    ll = VectorInputHelper.ParseLinkedListVector(tbLlInput.Text);
                    lbLlResult.Text = "Создан: " + ll;
                }
                catch (Exception ex) { lbLlResult.Text = ex.Message; }
            };

            bFill.Click += (s, e) => { if (!EnsureLL()) return; FillVectorDialog(ll); lbLlResult.Text = "Заполнено: " + ll; };
            bShow.Click += (s, e) => { if (!EnsureLL()) return; lbLlResult.Text = ll.ToString(); };
            bNorm.Click += (s, e) => { if (!EnsureLL()) return; lbLlResult.Text = "Норма: " + ll.GetNorm(); };
            bLen.Click += (s, e) => { if (!EnsureLL()) return; lbLlResult.Text = "Длина: " + ll.Length; };

            bGet.Click += (s, e) => { if (!EnsureLL()) return; int i = ToInt(tbLlIndex.Text); try { lbLlResult.Text = $"Элемент [{i}] = {ll[i]}"; } catch (Exception ex) { lbLlResult.Text = ex.Message; } };
            bSet.Click += (s, e) => { if (!EnsureLL()) return; int i = ToInt(tbLlIndex.Text); int v = ToInt(tbLlValue.Text); try { ll[i] = v; lbLlResult.Text = "После изменения: " + ll; } catch (Exception ex) { lbLlResult.Text = ex.Message; } };

            bAddEnd.Click += (s, e) => { if (!EnsureLL()) return; int v = ToInt(tbLlValue.Text); ll.AddToEnd(v); lbLlResult.Text = "После добавления в конец: " + ll; };
            bAddBeg.Click += (s, e) => { if (!EnsureLL()) return; int v = ToInt(tbLlValue.Text); ll.AddToBeginning(v); lbLlResult.Text = "После добавления в начало: " + ll; };
            bAddAt.Click += (s, e) => { if (!EnsureLL()) return; int pz = ToInt(tbLlIndex.Text); int v = ToInt(tbLlValue.Text); try { ll.AddAtPosition(pz, v); lbLlResult.Text = "После добавления в позицию: " + ll; } catch (Exception ex) { lbLlResult.Text = ex.Message; } };

            bRemEnd.Click += (s, e) => { if (!EnsureLL()) return; try { int x = ll.RemoveFromEnd(); lbLlResult.Text = $"Удалён {x}. Сейчас: {ll}"; } catch (Exception ex) { lbLlResult.Text = ex.Message; } };
            bRemBeg.Click += (s, e) => { if (!EnsureLL()) return; try { int x = ll.RemoveFromBeginning(); lbLlResult.Text = $"Удалён {x}. Сейчас: {ll}"; } catch (Exception ex) { lbLlResult.Text = ex.Message; } };
            bRemAt.Click += (s, e) => { if (!EnsureLL()) return; int pz = ToInt(tbLlIndex.Text); try { int x = ll.RemoveAtPosition(pz); lbLlResult.Text = $"Удалён {x}. Сейчас: {ll}"; } catch (Exception ex) { lbLlResult.Text = ex.Message; } };

            tabs.TabPages.Add(p);
        }

        private bool EnsureLL()
        {
            if (ll == null) { lbLlResult.Text = "Сначала создай вектор"; return false; }
            return true;
        }

        private void BuildMixedSumPage()
        {
            var p = new TabPage("Сложить разные типы");

            p.Controls.Add(new Label { Left = 20, Top = 20, Width = 260, Text = "Первый вектор (Array, через пробел):" });
            tbMixInput1 = new TextBox { Left = 290, Top = 16, Width = 700, Height = 30 };

            p.Controls.Add(new Label { Left = 20, Top = 58, Width = 260, Text = "Второй вектор (LinkedList, через пробел):" });
            tbMixInput2 = new TextBox { Left = 290, Top = 54, Width = 700, Height = 30 };

            var bSum = new Button { Left = 20, Top = 95, Width = 160, Height = 34, Text = "Сложить векторы" };
            var bShow = new Button { Left = 190, Top = 95, Width = 180, Height = 34, Text = "Показать оба вектора" };

            lbMixResult = new Label { Left = 20, Top = 145, Width = 1000, Height = 500 };

            p.Controls.Add(tbMixInput1); p.Controls.Add(tbMixInput2); p.Controls.Add(bSum); p.Controls.Add(bShow); p.Controls.Add(lbMixResult);

            bShow.Click += (s, e) =>
            {
                try
                {
                    var a = VectorInputHelper.ParseArrayVector(tbMixInput1.Text);
                    var l = VectorInputHelper.ParseLinkedListVector(tbMixInput2.Text);
                    lbMixResult.Text = $"Array: {a}\nLinkedList: {l}";
                }
                catch (Exception ex) { lbMixResult.Text = ex.Message; }
            };

            bSum.Click += (s, e) =>
            {
                try
                {
                    var a = VectorInputHelper.ParseArrayVector(tbMixInput1.Text);
                    var l = VectorInputHelper.ParseLinkedListVector(tbMixInput2.Text);
                    lbMixResult.Text = "Сумма: " + Vectors.SumSt(a, l);
                }
                catch (Exception ex) { lbMixResult.Text = ex.Message; }
            };

            tabs.TabPages.Add(p);
        }

        private void BuildArrayOfVectorsPage()
        {
            var p = new TabPage("Массив векторов");

            p.Controls.Add(new Label { Left = 20, Top = 20, Width = 130, Text = "Количество:" });
            tbAovCount = new TextBox { Left = 150, Top = 16, Width = 70, Height = 30, Text = "3" };
            var bCreateArr = new Button { Left = 230, Top = 15, Width = 210, Height = 32, Text = "Создать массив векторов" };

            p.Controls.Add(new Label { Left = 20, Top = 60, Width = 340, Text = "Добавление: тип (1-Array, 2-LinkedList)" });
            tbAovType = new TextBox { Left = 360, Top = 56, Width = 60, Height = 30, Text = "1" };
            p.Controls.Add(new Label { Left = 430, Top = 60, Width = 180, Text = "Вектор (через пробел):" });
            tbAovInput = new TextBox { Left = 610, Top = 56, Width = 380, Height = 30 };
            var bAdd = new Button { Left = 20, Top = 95, Width = 240, Height = 34, Text = "Добавить следующий вектор" };

            p.Controls.Add(new Label { Left = 20, Top = 142, Width = 70, Text = "Индекс A:" });
            tbAovIdx1 = new TextBox { Left = 90, Top = 138, Width = 60, Height = 30, Text = "0" };
            p.Controls.Add(new Label { Left = 170, Top = 142, Width = 70, Text = "Индекс B:" });
            tbAovIdx2 = new TextBox { Left = 240, Top = 138, Width = 60, Height = 30, Text = "1" };

            p.Controls.Add(new Label { Left = 320, Top = 142, Width = 90, Text = "Клон индекс:" });
            tbAovCloneIdx = new TextBox { Left = 410, Top = 138, Width = 60, Height = 30, Text = "0" };
            p.Controls.Add(new Label { Left = 490, Top = 142, Width = 90, Text = "Изм. индекс:" });
            tbAovEditIdx = new TextBox { Left = 580, Top = 138, Width = 60, Height = 30, Text = "0" };
            p.Controls.Add(new Label { Left = 660, Top = 142, Width = 95, Text = "Нов. значение:" });
            tbAovEditVal = new TextBox { Left = 755, Top = 138, Width = 80, Height = 30, Text = "999" };

            var bShow = new Button { Left = 20, Top = 180, Width = 120, Height = 34, Text = "Вывести" };
            var bEq = new Button { Left = 150, Top = 180, Width = 120, Height = 34, Text = "Сравнение" };
            var bMinMax = new Button { Left = 280, Top = 180, Width = 200, Height = 34, Text = "Мин/макс по координатам" };
            var bSortNorm = new Button { Left = 490, Top = 180, Width = 190, Height = 34, Text = "Сортировка по модулю" };
            var bClone = new Button { Left = 690, Top = 180, Width = 170, Height = 34, Text = "Клонировать вектор" };

            lbAovResult = new Label { Left = 20, Top = 225, Width = 1000, Height = 420 };

            p.Controls.Add(tbAovCount); p.Controls.Add(bCreateArr);
            p.Controls.Add(tbAovType); p.Controls.Add(tbAovInput); p.Controls.Add(bAdd);
            p.Controls.Add(tbAovIdx1); p.Controls.Add(tbAovIdx2);
            p.Controls.Add(tbAovCloneIdx); p.Controls.Add(tbAovEditIdx); p.Controls.Add(tbAovEditVal);
            p.Controls.Add(bShow); p.Controls.Add(bEq); p.Controls.Add(bMinMax); p.Controls.Add(bSortNorm); p.Controls.Add(bClone);
            p.Controls.Add(lbAovResult);

            bCreateArr.Click += (s, e) =>
            {
                int c = ToInt(tbAovCount.Text, 0);
                if (c <= 0) { lbAovResult.Text = "Количество должно быть больше 0"; return; }
                vectors = new IVectorable[c];
                aovAddPos = 0;
                lbAovResult.Text = $"Создан массив на {c} векторов.";
            };

            bAdd.Click += (s, e) =>
            {
                if (vectors == null) { lbAovResult.Text = "Сначала создай массив"; return; }
                if (aovAddPos >= vectors.Length) { lbAovResult.Text = "Массив уже заполнен"; return; }

                int type = ToInt(tbAovType.Text, 1);
                try
                {
                    IVectorable v = (type == 2)
                        ? (IVectorable)VectorInputHelper.ParseLinkedListVector(tbAovInput.Text)
                        : VectorInputHelper.ParseArrayVector(tbAovInput.Text);

                    vectors[aovAddPos] = v;
                    lbAovResult.Text = $"Добавлен [{aovAddPos}] = {v}";
                    aovAddPos++;
                }
                catch (Exception ex) { lbAovResult.Text = ex.Message; }
            };

            bShow.Click += (s, e) =>
            {
                if (!EnsureAov()) return;
                string txt = "";
                for (int i = 0; i < vectors.Length; i++) txt += $"[{i}] {vectors[i]}\n";
                lbAovResult.Text = txt;
            };

            bEq.Click += (s, e) =>
            {
                if (!EnsureAov()) return;
                int a = ToInt(tbAovIdx1.Text), b = ToInt(tbAovIdx2.Text);
                if (!CheckAovIdx(a) || !CheckAovIdx(b)) return;
                lbAovResult.Text = vectors[a].Equals(vectors[b]) ? "Векторы равны" : "Векторы не равны";
            };

            bMinMax.Click += (s, e) =>
            {
                if (!EnsureAov()) return;

                IVectorable min = vectors[0], max = vectors[0];
                var mins = new List<IVectorable> { min };
                var maxs = new List<IVectorable> { max };

                foreach (var v in vectors)
                {
                    int cmin = ((IComparable)v).CompareTo(min);
                    if (cmin < 0) { min = v; mins.Clear(); mins.Add(v); }
                    else if (cmin == 0 && !ReferenceEquals(v, min)) mins.Add(v);

                    int cmax = ((IComparable)v).CompareTo(max);
                    if (cmax > 0) { max = v; maxs.Clear(); maxs.Add(v); }
                    else if (cmax == 0 && !ReferenceEquals(v, max)) maxs.Add(v);
                }

                string txt = "Мин по числу координат:\n";
                foreach (var v in mins) txt += v + "\n";
                txt += "\nМакс по числу координат:\n";
                foreach (var v in maxs) txt += v + "\n";
                lbAovResult.Text = txt;
            };

            bSortNorm.Click += (s, e) =>
            {
                if (!EnsureAov()) return;
                var sorted = (IVectorable[])vectors.Clone();
                Array.Sort(sorted, new VectorNormComparer());

                string txt = "По возрастанию модуля:\n";
                for (int i = 0; i < sorted.Length; i++)
                    txt += $"[{i}] норма={sorted[i].GetNorm():F4} {sorted[i]}\n";

                lbAovResult.Text = txt;
            };

            bClone.Click += (s, e) =>
            {
                if (!EnsureAov()) return;

                int idx = ToInt(tbAovCloneIdx.Text);
                if (!CheckAovIdx(idx)) return;

                var original = vectors[idx];
                var clone = (IVectorable)((ICloneable)original).Clone();

                int editI = ToInt(tbAovEditIdx.Text);
                int editV = ToInt(tbAovEditVal.Text);
                if (editI < 0 || editI >= clone.Length) { lbAovResult.Text = "Индекс изменения вне диапазона"; return; }

                clone[editI] = editV;
                lbAovResult.Text = $"Оригинал: {original}\nКлон после изменения: {clone}\nEquals: {original.Equals(clone)}";
            };

            tabs.TabPages.Add(p);
        }

        private bool EnsureAov()
        {
            if (vectors == null) { lbAovResult.Text = "Сначала создай массив"; return false; }
            for (int i = 0; i < vectors.Length; i++)
                if (vectors[i] == null) { lbAovResult.Text = $"Не заполнен вектор [{i}]"; return false; }
            return true;
        }

        private bool CheckAovIdx(int idx)
        {
            if (idx < 0 || idx >= vectors.Length) { lbAovResult.Text = "Индекс вне границ массива"; return false; }
            return true;
        }

        private void BuildStreamsPage()
        {
            var p = new TabPage("Потоки");

            p.Controls.Add(new Label { Left = 20, Top = 20, Width = 190, Text = "Вектор (через пробел):" });
            tbStInput = new TextBox { Left = 210, Top = 16, Width = 760, Height = 30 };

            var bCreate = new Button { Left = 20, Top = 56, Width = 170, Height = 34, Text = "Создать из строки" };
            var bBinW = new Button { Left = 20, Top = 100, Width = 160, Height = 34, Text = "Записать в бинарный" };
            var bBinR = new Button { Left = 190, Top = 100, Width = 170, Height = 34, Text = "Прочитать из бинарного" };
            var bTxtW = new Button { Left = 370, Top = 100, Width = 160, Height = 34, Text = "Записать в текстовый" };
            var bTxtR = new Button { Left = 540, Top = 100, Width = 170, Height = 34, Text = "Прочитать из текстового" };
            var bSer = new Button { Left = 720, Top = 100, Width = 130, Height = 34, Text = "Сериализовать" };
            var bDes = new Button { Left = 860, Top = 100, Width = 130, Height = 34, Text = "Десериализовать" };

            lbStResult = new Label { Left = 20, Top = 175, Width = 1000, Height = 470 };

            p.Controls.Add(tbStInput); p.Controls.Add(bCreate);
            p.Controls.Add(bBinW); p.Controls.Add(bBinR); p.Controls.Add(bTxtW); p.Controls.Add(bTxtR); p.Controls.Add(bSer); p.Controls.Add(bDes);
            p.Controls.Add(lbStResult);

            bCreate.Click += (s, e) =>
            {
                try { stVec = VectorInputHelper.ParseArrayVector(tbStInput.Text); lbStResult.Text = "Создан: " + stVec; }
                catch (Exception ex) { lbStResult.Text = ex.Message; }
            };

            bBinW.Click += (s, e) =>
            {
                if (!EnsureStream()) return;
                try
                {
                    using (var fs = new FileStream("vector.bin", FileMode.Create))
                        Vectors.OutputVector(stVec, fs);
                    lbStResult.Text = "Записано в vector.bin";
                }
                catch (Exception ex) { lbStResult.Text = ex.Message; }
            };

            bBinR.Click += (s, e) =>
            {
                try
                {
                    using (var fs = new FileStream("vector.bin", FileMode.Open))
                    {
                        var v = Vectors.InputVector(fs);
                        lbStResult.Text = "Считан из бинарного: " + v;
                    }
                }
                catch (Exception ex) { lbStResult.Text = ex.Message; }
            };

            bTxtW.Click += (s, e) =>
            {
                if (!EnsureStream()) return;
                try
                {
                    using (var sw = new StreamWriter("vector.txt"))
                        Vectors.WriteVector(stVec, sw);
                    lbStResult.Text = "Записано в vector.txt";
                }
                catch (Exception ex) { lbStResult.Text = ex.Message; }
            };

            bTxtR.Click += (s, e) =>
            {
                try
                {
                    using (var sr = new StreamReader("vector.txt"))
                    {
                        var v = Vectors.ReadVector(sr);
                        lbStResult.Text = "Считан из текстового: " + v;
                    }
                }
                catch (Exception ex) { lbStResult.Text = ex.Message; }
            };

            bSer.Click += (s, e) =>
            {
                if (!EnsureStream()) return;
                try
                {
#pragma warning disable SYSLIB0011
                    IFormatter formatter = new BinaryFormatter();
                    using (var fs = new FileStream("vector.dat", FileMode.Create))
                        formatter.Serialize(fs, stVec);
#pragma warning restore SYSLIB0011
                    lbStResult.Text = "Сериализован в vector.dat";
                }
                catch (Exception ex) { lbStResult.Text = ex.Message; }
            };

            bDes.Click += (s, e) =>
            {
                try
                {
#pragma warning disable SYSLIB0011
                    IFormatter formatter = new BinaryFormatter();
                    using (var fs = new FileStream("vector.dat", FileMode.Open))
                    {
                        var loaded = (ArrayVector)formatter.Deserialize(fs);
                        lbStResult.Text = $"Оригинал: {stVec}\nДесериализован: {loaded}\nEquals: {(stVec != null && stVec.Equals(loaded))}";
                    }
#pragma warning restore SYSLIB0011
                }
                catch (Exception ex) { lbStResult.Text = ex.Message; }
            };

            tabs.TabPages.Add(p);
        }

        private bool EnsureStream()
        {
            if (stVec == null) { lbStResult.Text = "Сначала создай вектор из строки"; return false; }
            return true;
        }

        private static void FillVectorDialog(IVectorable v)
        {
            for (int i = 0; i < v.Length; i++)
            {
                string s = Microsoft.VisualBasic.Interaction.InputBox($"a[{i}] =", "Заполнение", "0");
                v[i] = int.TryParse(s, out int val) ? val : 0;
            }
        }
    }
}