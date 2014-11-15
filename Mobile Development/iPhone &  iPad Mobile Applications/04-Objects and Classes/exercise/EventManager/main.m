//
//  main.m
//  EventManager
//
//  Created by Venelin  on 10/26/14.
//  Copyright (c) 2014 Teleric Academy Courses. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "EventManager.h"

void printEvents(NSMutableArray *events)
{
    for (Event *ev in events) {
        NSLog(@"%@",ev);
    }
}

int main(int argc, const char * argv[])
{

    @autoreleasepool {
        
        
        EventManager *manager = [[EventManager alloc]init];
        //Create event
        Event *ev1 = [manager createEventWithTitle:@"Start" andCategory:@"Process" andDescription:@"startup closed mashines" andDate:[NSDate date] andGuests:@[@"guest1", @"guest2"]];
        
       Event *ev2 = [manager createEventWithTitle:@"Stop" andCategory:@"Process" andDescription:@"stop closed mashines" andDate:[NSDate date] andGuests:@[@"ivan", @"pesho"]];
        
       Event *ev3 = [manager createEventWithTitle:@"Stay alive" andCategory:@"Pending" andDescription:@"Stay closed mashines" andDate:[NSDate date] andGuests:@[@"Petq", @"Gosho"]];
        
//        NSLog(@"%@",ev1);
//         NSLog(@"%@",ev2);
//         NSLog(@"%@",ev3);
        
        //Add created events
        [manager addEvent:ev1];
        [manager addEvent:ev2];
        [manager addEvent:ev3];
        
        //List all events
        NSLog(@"\nList all events");
        NSMutableArray *events = [manager allEvents];
        printEvents(events);
        
        
        //List events by category
        NSLog(@"\nList events by category");
        NSMutableArray *filtredEvents = [manager allEventsByCategory:@"Process"];
         printEvents(filtredEvents);
        
        //Sort events by either date or title
        [manager sortEventsByDate:[NSDate date] orTitle:@"Start"];
        
        
    }
    return 0;
}

