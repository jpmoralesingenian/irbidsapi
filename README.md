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

### Other willing and unwilling sponsors

Here is a shoutout to the resources that made this hack possible: 

 * Thanks to IBM Watson, for the AI logic to check the accuyracy of a phrase https://dataplatform.cloud.ibm.com/docs/content/wsj/getting-started/wdp-apis.html
 * Thanks to http://www.englishspeak.com for providing the phrases and the audios that were srapped off their website to be included on the database
 * Thanks to Infotrans for the hosting of the database and the services and for Marco's and Carlos' time
 * Thanks to [Ingenian Software](https://www.ingenian.com) for the DNS services, the pizza, the money for the minutes needed to test and for Marlon's and Juan Pablo's time
 
## Prize category

This hack is a contestant in the **education** category

## Where the goods are

### Code
* The Github repository for the website https://github.com/cdazamolina/IRBIDS
* The Github repository for the API https://github.com/jpmoralesingenian/irbidsapi

## Application
* The app on a demo (will work for as long as it has money) +1 916 860 1204
* The website for the game http://irbids.ingenian.com
* The website for the API http://irbidsapi.ingenian.com
