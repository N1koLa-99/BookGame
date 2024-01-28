using System;
using System.Collections.Generic;

namespace GraphBook1._0
{
    internal class Program
    {
        const int MAX_DEPTH = 30;

        static void Main(string[] args)
        {
            GraphNode root = GraphStory();
            TraverseGame(root, 0);
        }

        private static void TraverseGame(GraphNode node, int depth)
        {
            if (depth >= MAX_DEPTH || node.ChildNodes.Count < 1)
            {
                Console.WriteLine("Прекалено дълго стоиш на едно място");
                return;
            }

            Console.WriteLine(node.StepDescription);

            GraphNode nextStep = UserChoice(node.ChildNodes);
            if (nextStep != null)
            {
                TraverseGame(nextStep, depth + 1);
            }
        }

        private static GraphNode UserChoice(List<GraphNode> childNode)
        {
            for (int i = 0; i < childNode.Count; i++)
            {
                Console.WriteLine($"({i + 1}) {childNode[i].StepDescription}");
            }

            int selectOption;
            if (int.TryParse(Console.ReadLine(), out selectOption))
            {
                selectOption--;

                if (selectOption >= 0 && selectOption < childNode.Count)
                {
                    return childNode[selectOption];
                }
            }

            // Връщаме null ако входът от потребителя не е валиден
            Console.WriteLine("Грешка при избор. Моля, опитайте отново.");
            return null;
        }

        private static GraphNode GraphStory()
        {
            GraphNode root = new GraphNode("Начало");
            root.Story = root.RootStoty();
            root.StepDescription = "Това е началото на твоето приключение.";


            GraphNode firstChoice = new GraphNode("Първия избор ako повярва");
            firstChoice.Story = firstChoice.FirstChoice();
            firstChoice.StepDescription = "Артър избира да вярва на странника ";

            GraphNode secondChoice = new GraphNode("Не вярва");
            secondChoice.Story = secondChoice.SecondChoice();
            secondChoice.StepDescription = "Артър избира да не вярва на странника";


            GraphNode messWithSpiders = new GraphNode("Сблъсъка с паяците");
            messWithSpiders.Story = messWithSpiders.MessWithSpiders();
            messWithSpiders.StepDescription = "Срещата с паяците";


            GraphNode battleWithSpiders = new GraphNode("Битката с паяците");
            battleWithSpiders.Story = battleWithSpiders.BattleWithSpider();
            battleWithSpiders.StepDescription = "Битката с паяците";



            GraphNode battleContinues = new GraphNode("битката продължава");
            battleContinues.Story = battleContinues.BattleContinues();
            battleContinues.StepDescription = "Започва кървава и ожесточена битка срещу Паяците";


            GraphNode mysteriousTemple = new GraphNode("Старинен храм");
            mysteriousTemple.Story = mysteriousTemple.MysteriousTemple();
            mysteriousTemple.StepDescription = "Младите воини забелязват Старинен храм";


            GraphNode exploreTemple = new GraphNode("Изследване на храма");
            exploreTemple.Story = exploreTemple.ExploreTemple();
            exploreTemple.StepDescription = "Артър и неговата дружина влиза и изследва  храма в търсене на нещо интересно";

            GraphNode fastMoving = new GraphNode("Пренебрегват храма");
            fastMoving.Story = fastMoving.FastMoving();
            fastMoving.StepDescription = "Решават че не искат да губят време и продължават напред";

            GraphNode movingForward = new GraphNode("продължават напред");
            movingForward.Story = movingForward.MovingForward();
            movingForward.StepDescription = "Продължават смело напред";

            GraphNode seekingHelp = new GraphNode("В търсене на помощ");
            seekingHelp.Story = seekingHelp.SeekingHelp();
            seekingHelp.StepDescription = "В търсене на Помощ";

            GraphNode village = new GraphNode("Селото");
            village.Story = village.Village();
            village.StepDescription = "Изследване наа селото";

            GraphNode fightWithDemons = new GraphNode("Минават като рамбо");
            fightWithDemons.Story = fightWithDemons.FightWithDemons();
            fightWithDemons.StepDescription = "Младите войни решават да се бият";

            GraphNode stealthPath = new GraphNode("Минават незабелязано");
            stealthPath.Story = stealthPath.StealthPath();
            stealthPath.StepDescription = "Младите войни решават да преминат незабелязано";

            root.ChildNodes.Add(firstChoice);// повярва
            root.ChildNodes.Add(secondChoice);// не вярва --> Край

            firstChoice.ChildNodes.Add(messWithSpiders);//  срещата с паяците

            messWithSpiders.ChildNodes.Add(battleWithSpiders);// чудят се дали да се бият
            messWithSpiders.ChildNodes.Add(mysteriousTemple);// бягат и стигат до храма

            battleWithSpiders.ChildNodes.Add(battleContinues);// бият се с паяците --> Край
            battleWithSpiders.ChildNodes.Add(mysteriousTemple);//бягат и стигат до храма

            mysteriousTemple.ChildNodes.Add(exploreTemple);// влизат в храма 
            mysteriousTemple.ChildNodes.Add(fastMoving);//пренебрегват храма

            fastMoving.ChildNodes.Add(village);// Отиват в селото за помощ
            fastMoving.ChildNodes.Add(seekingHelp);//правят си лагер --> Край

            exploreTemple.ChildNodes.Add(movingForward);// стигат до селото
            exploreTemple.ChildNodes.Add(seekingHelp);// правят си лагер --> Край

            movingForward.ChildNodes.Add(village);// Отиват в селото за помощ
            movingForward.ChildNodes.Add(seekingHelp);// правят си лагер --> Край

            village.ChildNodes.Add(fightWithDemons);// Финал --> Край
            village.ChildNodes.Add(stealthPath);// Финал --> Край

            return root;
        }
    }
}
