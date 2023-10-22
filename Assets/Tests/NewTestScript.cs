using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class NewTestScript
{
    private GameObject playerObject;
    private Health playerHealth;
    private Scrollbar playerHealthScrollbar;

    [SetUp]
    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator PlayerSpawnTest()
    {
        yield return new WaitForSeconds(3);
        FindPlayer();
        UnityEngine.Assertions.Assert.IsNotNull(playerObject);
    }

    [UnityTest]
    public IEnumerator IsPlayerTakesDamage()
    {
        yield return new WaitForSeconds(3);
        FindPlayer();
        float playerHealthBeforeDamage = playerHealth.CurrentHp;
        playerHealth.TakeDamage(50);

        yield return new WaitForSeconds(1);
        Assert.IsTrue(playerHealth.CurrentHp < playerHealthBeforeDamage);
    }

    [UnityTest]
    public IEnumerator IsPlayerHealthScrollBarUpdated()
    {
        yield return new WaitForSeconds(3);
        playerHealthScrollbar = GameObject.Find("PlayerHealthScrollbar").GetComponent<Scrollbar>();
        float playerHealthScrollbarValueBeforeDamage = playerHealthScrollbar.size;

        FindPlayer();
        playerHealth.TakeDamage(50);

        yield return new WaitForSeconds(1);
        Assert.IsTrue(playerHealthScrollbar.size < playerHealthScrollbarValueBeforeDamage);
    }

    [UnityTest]
    public IEnumerator IsFirstAidKitHealsPlayerAndHidesAfterThat()
    {
        yield return new WaitForSeconds(3);
        FindPlayer();
        playerHealth.TakeDamage(50);
        float playerHealthBeforeHeals = playerHealth.CurrentHp;
        GameObject firstAidKit = GameObject.Find("FirstAidKit");
        playerObject.transform.position = firstAidKit.transform.position;

        yield return new WaitForSeconds(1);
        Assert.IsTrue(playerHealth.CurrentHp > playerHealthBeforeHeals & !firstAidKit.activeInHierarchy);
    }

    [UnityTest]
    public IEnumerator IsPlayerGetCureHPInInventory()
    {
        yield return new WaitForSeconds(3);
        FindPlayer();
        playerHealth.TakeDamage(50);

        GameObject cureHPInventoryItemObject = GameObject.Find("DisplayGiveCureHPInventoryItem");

        playerObject.transform.position = cureHPInventoryItemObject.transform.position;

        yield return new WaitForSeconds(1);

        GameObject cureHPItemInInventory = GameObject.Find("GiveCureHPInventoryItem(Clone)");
        UnityEngine.Assertions.Assert.IsNotNull(cureHPItemInInventory);
    }

    private void FindPlayer()
    {
        playerObject = GameObject.Find("Player(Clone)");
        playerHealth = playerObject.GetComponent<Health>();
    }
}
