<template>
    <apexchart
        type="pie"
        width="100%"
        :options="chartOptions"
        :series="series"
    ></apexchart>
</template>

<script>
import { LIMIT_LABEL } from "@/utils/constants";

export default {
    name: "ChartPieComponent",
    props: {
        series: Array,
        labels: Array,
    },
    data(props) {
        return {
            chartOptions: {
                chart: {
                    type: "pie",
                },
                labels: props.labels?.map((l) => {
                    return (
                        l?.substring(0, LIMIT_LABEL) +
                        (l?.length > LIMIT_LABEL ? "..." : "")
                    );
                }),
                responsive: [
                    {
                        breakpoint: 480,
                        options: {
                            chart: {
                                width: 200,
                            },
                            legend: {
                                position: "right",
                            },
                        },
                    },
                ],
            },
        };
    },
};
</script>
