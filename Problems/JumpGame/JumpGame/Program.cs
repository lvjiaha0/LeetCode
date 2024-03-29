﻿using System;
using System.Linq;


//55. 跳跃游戏
//给定一个非负整数数组 nums ，你最初位于数组的 第一个下标 。
//数组中的每个元素代表你在该位置可以跳跃的最大长度。
//判断你是否能够到达最后一个下标。

//示例 1：
//输入：nums = [2,3,1,1,4]
//输出：true
//解释：可以先跳 1 步，从下标 0 到达下标 1, 然后再从下标 1 跳 3 步到达最后一个下标。

//示例 2：
//输入：nums = [3,2,1,0,4]
//输出：false
//解释：无论怎样，总会到达下标为 3 的位置。但该下标的最大跳跃长度是 0 ， 所以永远不可能到达最后一个下标。

//提示：
//1 <= nums.length <= 3 * 104
//0 <= nums[i] <= 105
namespace JumpGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //var a = CanJump(new int[] { 2, 3, 1, 1, 4 });//true
            //var a1 = CanJump(new int[] { 4, 5, 3, 2, 1, 0, 3, 4 });//true
            var a2 = CanJump(new int[] { 1, 0, 1, 0 });//false
            var a3 = CanJump(new int[] { 2, 0, 0 });//true
            var a4 = CanJump(new int[] { 3, 2, 1, 0, 4 });//false
            Console.ReadKey();
        }

        //作者：ikaruga
        //链接：https://leetcode-cn.com/problems/jump-game/solution/55-by-ikaruga/

        //解题思路：
        //如果某一个作为 起跳点 的格子可以跳跃的距离是 3，那么表示后面 3 个格子都可以作为 起跳点。
        //可以对每一个能作为 起跳点 的格子都尝试跳一次，把 c 不断更新。
        //如果可以一直跳到最后，就成功了。
        public static bool CanJump(int[] nums)
        {
            //能跳到最远的距离
            int canJumpMaxSteps = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                //如果当前位置对于可跳最远距离都达不到，则跳不动了
                if (i > canJumpMaxSteps) return false;
                //更新能跳到最远的距离
                canJumpMaxSteps = Math.Max(canJumpMaxSteps, i + nums[i]);
            }

            return true;
        }
    }
}
