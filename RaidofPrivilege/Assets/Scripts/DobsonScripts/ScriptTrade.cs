using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScriptTrade : MonoBehaviour {

    public ScriptPlayer trader;
    public ScriptPlayer tradie;

    int offerWool;
    int offerLumber;
    int offerGrain;
    int offerBrick;

    int wantWool;
    int wantLumber;
    int wantGrain;
    int wantBrick;

    public ScriptTrade(ScriptPlayer Trader, ScriptPlayer Tradie, int OfferWool, int OfferLumber, int OfferGrain, int OfferBrick,
                    int WantWool, int WantLumber, int WantGrain, int WantBrick)
    {
        trader = Trader;
        tradie = Tradie;
        offerWool = OfferWool;
        offerLumber = OfferLumber;
        offerGrain = OfferGrain;
        offerBrick = OfferBrick;
        wantWool = WantWool;
        wantLumber = WantLumber;
        wantGrain = WantGrain;
        wantBrick = WantBrick;
    }

    public ScriptTrade(ScriptPlayer Trader, ScriptPlayer Tradie, int WantWool, int WantLumber, int WantGrain, int WantBrick)
    {
        offerWool = WantWool;
        offerLumber = WantLumber;
        offerGrain = WantGrain;
        offerBrick = WantBrick;
        wantWool = 0;
        wantLumber = 0;
        wantGrain = 0;
        wantBrick = 0;
    }

    void AcceptTrade()
    {
        tradie.ChangeBrick(-wantBrick);
        tradie.ChangeBrick(offerBrick);
        tradie.ChangeGrain(-wantGrain);
        tradie.ChangeGrain(offerGrain);
        tradie.ChangeWood(-wantLumber);
        tradie.ChangeWood(offerLumber);
        tradie.ChangeWool(-wantWool);
        tradie.ChangeWool(offerWool);
        tradie.outboundTrade.Enqueue(new ScriptTrade(tradie, trader, wantWool, wantLumber,
                                        wantGrain, wantBrick));
    }

}
