<template>
    <ag-charts :options="options" />
</template>

<script>
import { ref } from "vue";
import { AgCharts } from "ag-charts-vue3";

export default {
    name: "VueAGBarComponent",
    props: {
        title: String,
        subtitle: String,
        data: Object,
    },
    components: {
        "ag-charts": AgCharts,
    },
    setup(props) {
        const dataObject = props.data.reduce((acc, item) => {
            acc[item.name] = item.value;
            return acc;
        }, {});
        const options = ref({
            // data: props.data,
            title: {
                text: props.title,
            },
            subtitle: {
                text: props.subtitle,
            },
            data: [
                {
                    quarter: props.title,
                    ...dataObject,
                    // haha: 2,
                    // hehe: 1,
                },
            ],
            series: [
                ...props.data.map((d) => {
                    return {
                        type: "bar",
                        xKey: "quarter",
                        yKey: d.name,
                        yName: d.name,
                    };
                }),
                // {
                //     type: "bar",
                //     xKey: "quarter",
                //     yKey: "haha",
                //     yName: "haha",
                // },
                // {
                //     type: "bar",
                //     xKey: "quarter",
                //     yKey: "hehe",
                //     yName: "hehe",
                // },
            ],
        });

        return {
            options,
        };
    },
};
</script>
