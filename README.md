We are starting with a simple Domain>Test structure. This won't follow DDD to the core since it requires a concept of identities, which don't seem to appear in the scope of this kata. 

1. We start with an assumption that the measures are whole positive numbers 
2. Parcel behaviour is embedded in the Parcel object 
3. SpeedyShipping has an internal constructor to prevent it from being added to order items without going through the Order object
4. Heavy parcels are going to be treated as separate type of entities, and not a variation, since they don't follow any of the price rules for the other packages. If the intent in the requirement was otherwise, this could be achieved by creating a flag in the Parcel class, or better create an abstract class for generic Parcel,with specific methods to calculate cost, and have both the normal and heavy parcels implementing it 
5. On the discounts it seems that we have a somewhat obvious order of execution to get the best overall discount - small and medium discounts, don't intervene with each other, and the mixed parcel, is worse than either the small or medium ones if we only had small or medium parcels
6. This was developed following TDD as much as possible - there can be some improvements to the testing suite, for example bundling some of the current tests together and parametrising the expected and 'because' arguments. We can also create a Theory for the OrderTests to allow for bigger collections with more variation to be tested. 
7. This also used the Pomodoro technique to follow time spend, since the requirement was to not spend more than 2 hours, which means that point was not done - there is a description in the Order class of how it would have been implemented
8. Some of the other "hardcoded" values can be moved to a configuration class similar to WeightLimits, but for a smaller scope like this static master class should work fine. Otherwise configurable without redeployment is always better.
9. There are 107 tests covering most of points 1-4
