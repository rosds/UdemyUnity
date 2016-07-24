using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;


[TestFixture]
public class ActionMasterTests
{
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action gameOver = ActionMaster.Action.GameOver;
	private ActionMaster actionMaster;

	[SetUp]
	public void Setup ()
	{
		actionMaster = new ActionMaster();
	}

    [Test]
    public void T00OneStrikeReturnsEndTurn()
    {
    	Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T01Bowl8ReturnsTidy() {
		Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T02Bowl5ReturnsTidy() {
    	Assert.AreEqual(tidy, actionMaster.Bowl(5));
    }

    [Test]
    public void T03Bowl4AndThen6ReturnsEndTurn() {
    	actionMaster.Bowl(4);
    	Assert.AreEqual(endTurn, actionMaster.Bowl(6) );
    }

    [Test]
    public void T04BowlAStrike9TimesAndThen4ReturnsTidy ()
	{
		for (int i = 0; i < 9; i++) {
			actionMaster.Bowl(10);
		}
    	Assert.AreEqual(tidy, actionMaster.Bowl(4));
    }

    [Test]
    public void T05Bowl9StrikesAndThen3And7ReturnsReset ()
	{
		for (int i = 0; i < 9; i++) {
			actionMaster.Bowl(10);
		}
		actionMaster.Bowl(3);
    	Assert.AreEqual(reset, actionMaster.Bowl(7));
    }

    [Test]
    public void T06Bowl10StrikesReturnsReset ()
	{
		for (int i = 0; i < 9; i++) {
			actionMaster.Bowl(10);
		}
    	Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

	[Test]
    public void T07Bowl11StrikesReturnsReset ()
	{
		for (int i = 0; i < 10; i++) {
			actionMaster.Bowl(10);
		}
    	Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T08Bowl9StrikesThen5And4ReturnsGameOver ()
	{
		for (int i = 0; i < 9; i++) {
			actionMaster.Bowl(10);
		}
		actionMaster.Bowl(5);
    	Assert.AreEqual(gameOver, actionMaster.Bowl(4));
    }

    [Test]
    public void T09Bowl12ReturnsGameOver ()
	{
		for (int i = 0; i < 11; i++) {
			actionMaster.Bowl(10);
		}
    	Assert.AreEqual(gameOver, actionMaster.Bowl(10));
    }
}