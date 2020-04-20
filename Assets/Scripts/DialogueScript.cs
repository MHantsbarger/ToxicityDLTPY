using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueScript : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public GameObject choice1;
    public GameObject choice2;
    public GameObject continueButton;
    bool choiceBool;

    private Queue<string> sentences;

    private void Start() {
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue dialogue) {
        choiceBool = false;

        Debug.Log("Starting convo with " + dialogue.name);
        nameText.text=dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();

        if (dialogue.choice != null) {
            choiceBool = true;
            sentences.Enqueue(dialogue.choice);
            choice1.GetComponentInChildren<Text>().text = dialogue.option1;
            choice2.GetComponentInChildren<Text>().text = dialogue.option2;
            choice1.GetComponent<Button>().onClick.RemoveAllListeners();
            choice2.GetComponent<Button>().onClick.RemoveAllListeners();
            choice1.GetComponent<Button>().onClick.AddListener(() => dialogue.nextScene1.GetComponent<DialogueTrigger>().TriggerDialogue());
            choice2.GetComponent<Button>().onClick.AddListener(() => dialogue.nextScene2.GetComponent<DialogueTrigger>().TriggerDialogue());
        }
        choice1.SetActive(false);
        choice2.SetActive(false);
        continueButton.SetActive(true);
    }

    public void DisplayNextSentence() {
        if (sentences.Count ==0) {
            EndDialogue();
            return;
        }
        if (sentences.Count ==1 && choiceBool) {
            choice1.SetActive(true);
            choice2.SetActive(true);
            continueButton.SetActive(false);
            //enable choice buttons here
        }
        string sentence =sentences.Dequeue();
        Debug.Log(sentence);
        dialogueText.text = sentence;
    }

    void EndDialogue() {
        Debug.Log("End of convo");
    }
    //https://www.youtube.com/watch?v=_nRzoTzeyxU

    // Narrative Assignment base for our game:
    // Scene 1:After a long day of school, my best friend (Liam) decided to bring me to a new internet
    // cafe and try some competitive games. At the very beginning, I felt quite nervous, because I was 
    // new to the competitive game community and Liam was already a veteran in completive games. As Liam 
    // recommended before, I started to play rank mode in League of Legends. When I got into the part of 
    // picking champs, I picked my favorite Teemo as a support role, although I knew it was a very unusual 
    // pick in rank. After I locked in my champ I told my team that it was my first time to play rank, that 
    // “GG” just popped up on the chat box. Because Liam was watching, he explained to me that the “GG” 
    // could be used as a sarcasm sometime, and told me to just ignore the chat box most of the time.
    // When I got into the game, because the opposing team had a champ called Blitzcrank which is a champ 
    // that has an ability that pulls the opponent enemy  to him, they decide to invade our jungle, hide 
    // in the bush, and wait for our team to face check the bush. Unfortunately, we didn’t know the enemy’s 
    // conspiracy, So that one of the opponents got triple kills even before the minions came out from the 
    // base. Right after that [Player A] just said “20ff” in the chat box which means surrender at 20 mins. 
    // It was then I realized that the rank mode is a bit different than the casual normal mode, people 
    // were taking the game way more seriously. During the early game, because of the counter relationship 
    // between champs, our team had a hard time farming and got slowly destroyed in lane. I could tell that 
    // everyone in my team was becoming stressed when I started seeing a lot of pings in game and frustrated 
    // conversation in the chat box.

    // Scene 2:Despite the rough start, we managed to hold on and keep our opponents from making an early push 
    // into our base.  It was very apparent that a few of my teammates knew what they were doing; they managed 
    // to catch up in levels relatively quickly, which prevented the enemy team’s early advantage from widening. 
    // I was doing my best to play to my role; my friend gave me invaluable advice on where to watch out for 
    // wards and where the enemy Blitzcrank was, which saved me from getting ganked early on. Although we had 
    // lost most of our towers, we managed to push back the enemy waves and after a lucky teamfight my team was 
    // able to barrel down the midlane and start attacking their base. Still, my teammate’s attitudes hadn’t 
    // changed much, and in particular one teammate continued calling me names, complaining that I was 
    // underleveled, and declaring that we were “lucky to win that 4v5”. I could tell that even my friend was 
    // getting bothered by them.

    // Scene 3:Shortly after the 20 minute mark, [Player A] called for a surrender vote, just like he said he 
    // would. Immediately another player also voted yes, saying “lol gg ez”. The third player also voted yes, 
    // after saying  and the fourth started toggling their vote between yes and no. Seeing them messing around 
    // with their votes I suddenly had inspiration for revenge. With a small smile I voted yes for surrender. 
    // Instantly the “defeat” screen popped up, and my teammates started frantically posting in chat. My friend 
    // gave me a quizzical look, “Why’d you do that? You were winning.” I shrugged and could only manage, “I 
    // just- wanted to get back at them.” Liam shook his head, “You were doing great! You can’t let them get 
    // to you. You just could have reported and blocked them. You lost a bit of ELO for that match and for 
    // what? They don’t matter.”
    // However, there was a proverb that lookers-on see most of the game. Liam as a spector don’t have the 
    // same experience as me. He wanted me to win a game, as a League veteran, he said, “Let me carry you this 
    // time, and don’t care about the things unrelated to the game. Just have fun.”

    // I started to be serious about the game, so I just picked Malphite, which is a good champ for team fighting. 
    // Nevertheless, the other two of three pick Yasuo (similar champ to Teemo) and Teemo. The last one just said, 
    // “Yasuo and Teemo? GG, 20 throw.” And also Liam cannot calm down and just typed three question marks. With 
    // no doubt, those two picks affected Liam’s emotion. When I saw that Teemo, I was just like seeing the Teemo 
    // I played last game. I can somehow understand that Teemo and maybe Yasuo. They are not  throwing the game, 
    // but just want to have fun. After 20 minutes, the scenario is copied, and the one said throw start the 
    // surrender vote (1/5), although we are on the way to win the game.Then, immediately, the vote become 3/5, 
    // and I know that was Yasuo and Teemo because I can see Liam’s screen. However, Liam’s mood is somehow 
    // collapsed when finding his facial emotion. I just say, “Do you remember the last game Teemo? And do you 
    // remember the things you told me? Just win the game, bro.” Liam seemed released after hearing my words, 
    // smiled and replied “OK, let’s win the game.”



}
