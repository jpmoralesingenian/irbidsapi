# IRBIDS
# I read but I don't speak

This is our entry for the TADHack-mini Phoenix with Avaya ENGAGE, that took place between Feb 1 and Feb 2, 2020 for more information on the Hackathon please check https://tadhack.com/2020/mini-phoenix/

## The problem

When non-natives try to learn a second language, one of the biggest barriers for it is shyness and self-conciousness and it is very common 
to hear, when talking about a second language that "I can read it, but I don't speak it", or in spanish "Lo entiendo pero no lo hablo".

This hack tries to address this by creating an engaging way to learn english for non-natives. It attempts to reduce the self consciousness by providing an automated way of grading, and by using the phone. 

## The Hack

We created a game that uses artificial intelligence to help improve the pronunciation of non-native speakers using the phone. 
There is a voice app that you can call at +1 916 860 1204. The app will ask you to repeat a given phrase and check how well you did it. Your score will be saved on a database and you will be able to see how it improves over time. The results are avaiable on http://irbids.ingenian.com

## The team

This hack is collaboration effort between two companies, based in Bogotá, Colombia (South America). 
The team mebers are: 

 * **Marco Castro** [Infotrans]: The one with the idea of participating on the hackathon, he is the one that got the people together, and is the one that represent the team on-site at Phoenix.
 
 * **Carlos Daza** [Infotrans]: He created the gameification component and the website that can be accessed at http://irbids.ingenian.com

 * **Marlon Acosta** [Ingenian]: He is the zang wizard, he created the call flow and the messages that appear on the phone call. 

 * **Juan Pablo Morales** [Ingenian]: He created the services that the Zang callflow uses, wrote the data to a database and invoked IBM's Watson to read the audio saved by zang to test the accuracy of what is being said

## Sponsor's resources

The whole voice flow is made using the resources provided by Avaya and available at https://cloud.zang.io This means the phone number used, and the voice routing and the voice recording are provided by Avaya.

## Prize category

This hack is a contestant in the **education** category

