\# TowerDefense



一个用 Unity 制作的 3D 塔防游戏（开发中，暂未完成）。



\## 玩法



敌人沿路径向终点移动，路上的塔会自动锁定最近的敌人开火。

敌人被击杀或走到终点：走到终点会扣除玩家生命值。



\## 已实现



\- 敌人沿路径点移动（waypoints 数组 + Vector3.MoveTowards）

\- 塔自动检测范围内最近的敌人（Physics.OverlapSphere）

\- 塔转向目标、定时开火

\- 敌人血量、受伤、死亡

\- 波次生成（Prefab + Instantiate + 运行时注入路径点）

\- 玩家生命值、漏怪扣血



\## 运行方式



1\. 安装 Unity 2022.3 LTS

2\. 用 Unity Hub 打开本项目

3\. 打开 `Assets/Scenes/Main.unity`

4\. 点 Play



\## 键技术点



\- 单例模式（PlayerHealth.Instance）

\- 预制体与运行时依赖注入

\- 短路求值、边界条件处理

